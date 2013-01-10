using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.Data;
using Sys.ViewManager;
using Sys.Security;
using System.IO;
using Sys.SmartList.DpoClass;
using Sys.ViewManager.Utils;
using Sys.ViewManager.DevEx;
using Sys.ViewManager.Security;
using Tie;

namespace Sys.SmartList.Forms
{
    public partial class SmartListMaintenanceForm : BaseForm
    {
        private TreeDpoView<CommandNodeDpo> treeView = new TreeDpoView<CommandNodeDpo>();

        BindDpo<CommandNodeDpo> binding = null;

        TextBox tbproperties = new TextBox();
        TextBox tbAccessLevel = new TextBox();
        TextBox tbTy = new TextBox();

        TextBox tbCreator = new TextBox();

        public SmartListMaintenanceForm()
        {
            InitializeComponent();
            treeView.Dock = DockStyle.Fill;
            treeView.ImageList = CommandTree.ImageList;

            this.splitContainer1.Panel1.Controls.Add(treeView);
            TreeNode root = new TreeNode("COMMAND");
            treeView.Nodes.Add(root);
            treeView.ToNodeText = dpo => string.Format("[{0}] {1}", dpo.NodeId, dpo.NodeText); 
            treeView.DataSource = new TableReader<CommandNodeDpo>().ToList().OrderBy(dpo => dpo.OrderBy);
            treeView.BuildTreeView(root, 0);

            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
            treeView.MouseDoubleClick += new MouseEventHandler(treeView_MouseDoubleClick);

            treeView.AllowDrop = true;





            //------------------------------------------------------------------------------



            this.tbSetting.SelectionChanged += JRichTextBoxPostionDelegate;
            this.tbScript.SelectionChanged += JRichTextBoxPostionDelegate;
            this.tbParameter.SelectionChanged += JRichTextBoxPostionDelegate;


            this.tbSetting.AcceptsTab = true;
            this.tbScript.AcceptsTab = true;
            this.tbParameter.AcceptsTab = true;

            this.FormClosed += delegate(object sender, FormClosedEventArgs e)
            {
                this.InformationMessage = "";
            };

            this.rgViewMode.LoadEnum<DataViewMode>();
            this.icbImage.Load(CommandTree.ImageList, CommandTree.Items);

            foreach (var provider in DataProviderManager.Instance.Providers)
            {
                this.comboDataProviders.Items.Add(provider.Value.Name);
            }

            CommandNodeDpo dpo1 = new CommandNodeDpo();
            binding = new BindDpo<CommandNodeDpo>(dpo1);

            binding.Bind(this.tbID, CommandDpo._ID);
            binding.Bind(this.tbParentID, CommandDpo._ParentID);

            binding.Bind(this.tbLabel, CommandDpo._Label);
            binding.Bind(this.tbDescription, CommandDpo._Description);

            binding.Bind(this.tbSetting, CommandDpo._Setting_Script);
            binding.Bind(this.tbScript, CommandDpo._Sql_Command);
            binding.Bind(this.tbParameter, CommandDpo._User_Layout);
            binding.Bind(this.tbproperties, CommandDpo._Header_Footer);
            binding.Bind(this.tbAccessLevel, CommandDpo._Access_Level);
            binding.Bind(this.tbTy, CommandDpo._Ty);

            binding.Bind(this.cbControlled, CommandDpo._Controlled);
            binding.Bind(this.cbEnabled, CommandDpo._Enabled);
            binding.Bind(this.cbVisible, CommandDpo._Visible);
            binding.Bind(this.cbReleased, CommandDpo._Released);

            binding.Bind(this.tbCreator, CommandDpo._Owner_ID);
            binding.Bind(this.rgViewMode, CommandDpo._ViewMode);
            binding.Bind(this.richEditControl1, "HtmlText", CommandDpo._Help);
            binding.Bind(this.icbImage, CommandDpo._Image_Index);

            binding.Bind<ComboBox, int>(this.comboDataProviders,
                    (control, value) => control.SelectedItem = DataProviderManager.Instance.GetConnection(value).Name,
                    (control) => (int)DataProviderManager.Instance.GetProvider((string)control.SelectedItem),
                    CommandDpo._Data_Provider);

            if (tbproperties.Text != "")
            {
                VAL properties = Script.Evaluate(tbproperties.Text);
                VAL header = properties["Header"];
                VAL footer = properties["Footer"];

                if (header.Defined)
                {
                    tbHeader1.Text = header[0].Str;
                    tbHeader2.Text = header[1].Str;
                    tbHeader3.Text = header[2].Str;
                }

                if (footer.Defined)
                {
                    tbFooter1.Text = footer[0].Str;
                    tbFooter2.Text = footer[1].Str;
                    tbFooter3.Text = footer[2].Str;
                }

            }

        }



        void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NTreeNode<CommandNodeDpo> node = treeView.SelectedDpoNode;
            if (node == null)
                return;

            var form = new MainForm(node.Item.NodeId);
            form.PopUp(this);
        }

        void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Action == TreeViewAction.ByMouse)
            {
                NTreeNode<CommandNodeDpo> node = (NTreeNode<CommandNodeDpo>)e.Node;
                if (node != null)
                {
                    binding.Apply();
                    if ((binding.Dpo as CommandDpo).ID !=0 && binding.Dpo.Changed(CommandDpo._ID, CommandDpo._OrderBy))
                    {
                        if (MessageBox.Show(this, string.Format("Do you want to save your changes om {0}# {1}?", (binding.Dpo as CommandDpo).ID, (binding.Dpo as CommandDpo).Label),
                            "Confirmation", 
                            MessageBoxButtons.YesNo, 
                            MessageBoxIcon.Question) == DialogResult.Yes)
                            
                            binding.SaveDpo();
                    }

                    binding.Dpo = (CommandNodeDpo)node.Item;
                    binding.Reset();
                }
            }
        }

        private void btnSaveOrderBy_Click(object sender, EventArgs e)
        {
            treeView.SaveOrderBy();
        }



        private void Backup()
        {
            WriteFile(string.Format("Commands.{0}.SQL#{1:yyyy.mm.dd-hhmmss}.sql", this.tbID.Text, DateTime.Now), this.tbScript.Text);
            WriteFile(string.Format("Commands.{0}.Script#{1:yyyy.mm.dd-hhmmss}.tie", this.tbID.Text, DateTime.Now), this.tbSetting.Text);
            WriteFile(string.Format("Commands.{0}.Form#{1:yyyy.mm.dd-hhmmss}.tie", this.tbID.Text, DateTime.Now), this.tbParameter.Text);
        }
        private void WriteFile(string fileName, string text)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(text);
            sw.Close();
        }

        private void JRichTextBoxPostionDelegate(object sender, System.EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            this.InformationMessage = new RichText(rtb).ToString();
        }



        private void btnSaveCommand_Click(object sender, EventArgs e)
        {
            tbAccessLevel.Text = ((int)SecurityLevel.PublicAccess).ToString();
            tbTy.Text = ((int)SecurityType.SmartList).ToString();

            VAL properties = new VAL();
            VAL header = VAL.Array(3);
            VAL footer = VAL.Array(3);

            header[0] = new VAL(tbHeader1.Text);
            header[1] = new VAL(tbHeader2.Text);
            header[2] = new VAL(tbHeader3.Text);

            footer[0] = new VAL(tbFooter1.Text);
            footer[1] = new VAL(tbFooter2.Text);
            footer[2] = new VAL(tbFooter3.Text);

            properties["Header"] = header;
            properties["Footer"] = footer;

            this.tbproperties.Text = properties.ToString();


            if (tbCreator.Text == "")
                tbCreator.Text = Account.CurrentUser.UserID.ToString();


            BeginLog();
            AddLog((DPObject)binding.Dpo);
            binding.ConfirmAndSave(this.tbLabel.Text);
            EndLog();

            InformationMessage = string.Format("Smart List Command {0} is saved.", this.tbLabel.Text);

            this.DialogResult = DialogResult.Yes;
#if DEBUG
            Backup();
#endif

            CommandNodeDpo dpo = (CommandNodeDpo)binding.Dpo;
            treeView.SelectedDpoNode.Text = string.Format("[{0}] {1}", dpo.ID, dpo.Label);
        }


        private void btnHistory_Click(object sender, EventArgs e)
        {
            CommandDpo dpo = new CommandDpo();
            dpo.ID = Int32.Parse(this.tbID.Text);
            dpo.Load();

            LogHistoryControl history = new LogHistoryControl();
            history.DPObject = dpo;
            history.LoadHistory();

            //history.AllowCellMerge = true;
            history.HideNotLogged = true;
            history.GridView.OptionsBehavior.Editable = true;

            Sys.ViewManager.Utils.Function.Popup(this, history, "Command History:" + dpo.Label, new Size(800, 360), this.Location + new Size(200, 300));

        }

       

        private void rgViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum mode = this.rgViewMode.GetEnum();

            if (mode != null)
            {
                this.btnBuildReport.Visible = (DataViewMode)mode == DataViewMode.Report;
                this.btnEditReport.Visible = (DataViewMode)mode == DataViewMode.Report;
            }
            else
            {
                this.btnBuildReport.Visible = false;
                this.btnEditReport.Visible = false;
            }
        }

        private void btnBuildReport_Click(object sender, EventArgs e)
        {
            Configuration configuration = (Configuration)binding.Dpo;
            DpoReportStorage.Register(configuration);

            var form = new DevExpress.XtraReports.UserDesigner.XRDesignForm();
            string url = configuration.RepxItem.url;
            form.OpenReport(url);
            form.ShowDialog(this);
        }

        private void btnEditReport_Click(object sender, EventArgs e)
        {
            Configuration configuration = (Configuration)binding.Dpo;
            BaseForm form = new ReportMaintenanceForm(configuration);
            form.PopDialog(this);
        }

    }
}
