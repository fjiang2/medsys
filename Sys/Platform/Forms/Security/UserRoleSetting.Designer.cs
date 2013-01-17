namespace Sys.Platform.Forms
{
    partial class UserRoleSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRoleSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddUser = new System.Windows.Forms.ToolStripButton();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.lvUserRoles = new System.Windows.Forms.ListView();
            this.lvAllRoles = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnRemoveRole = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Employees";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripButtonRoleSetting,
            this.toolStripButtonAddUser});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(798, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Sys.Platform.Properties.Resources.saveHS;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripButtonRoleSetting
            // 
            this.toolStripButtonRoleSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonRoleSetting.Image = global::Sys.Platform.Properties.Resources.user;
            this.toolStripButtonRoleSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRoleSetting.Name = "toolStripButtonRoleSetting";
            this.toolStripButtonRoleSetting.Size = new System.Drawing.Size(116, 22);
            this.toolStripButtonRoleSetting.Text = "Configurate Role";
            this.toolStripButtonRoleSetting.Click += new System.EventHandler(this.toolStripButtonRoleSetting_Click);
            // 
            // toolStripButtonAddUser
            // 
            this.toolStripButtonAddUser.Image = global::Sys.Platform.Properties.Resources.user_add;
            this.toolStripButtonAddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddUser.Name = "toolStripButtonAddUser";
            this.toolStripButtonAddUser.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonAddUser.Text = "Add";
            this.toolStripButtonAddUser.Click += new System.EventHandler(this.toolStripButtonAddUser_Click);
            // 
            // lvUsers
            // 
            this.lvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvUsers.Location = new System.Drawing.Point(2, 53);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(320, 462);
            this.lvUsers.TabIndex = 2;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvUsers_ItemSelectionChanged);
            // 
            // lvUserRoles
            // 
            this.lvUserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvUserRoles.Location = new System.Drawing.Point(329, 53);
            this.lvUserRoles.Name = "lvUserRoles";
            this.lvUserRoles.Size = new System.Drawing.Size(195, 462);
            this.lvUserRoles.TabIndex = 5;
            this.lvUserRoles.UseCompatibleStateImageBehavior = false;
            this.lvUserRoles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvUserRoles_MouseDoubleClick);
            // 
            // lvAllRoles
            // 
            this.lvAllRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAllRoles.Location = new System.Drawing.Point(601, 53);
            this.lvAllRoles.Name = "lvAllRoles";
            this.lvAllRoles.Size = new System.Drawing.Size(185, 462);
            this.lvAllRoles.TabIndex = 5;
            this.lvAllRoles.UseCompatibleStateImageBehavior = false;
            this.lvAllRoles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvUserRoles_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Assigned Roles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Not Assigned Roles";
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(536, 110);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(50, 23);
            this.btnAddRole.TabIndex = 6;
            this.btnAddRole.Text = "<<";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnRemoveRole
            // 
            this.btnRemoveRole.Location = new System.Drawing.Point(536, 150);
            this.btnRemoveRole.Name = "btnRemoveRole";
            this.btnRemoveRole.Size = new System.Drawing.Size(50, 23);
            this.btnRemoveRole.TabIndex = 6;
            this.btnRemoveRole.Text = ">>";
            this.btnRemoveRole.UseVisualStyleBackColor = true;
            this.btnRemoveRole.Click += new System.EventHandler(this.btnRemoveRole_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(119, 33);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentUser.TabIndex = 7;
            // 
            // UserRoleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 527);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnRemoveRole);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.lvAllRoles);
            this.Controls.Add(this.lvUserRoles);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "UserRoleSetting";
            this.Text = "User Roles Setting";
            this.Load += new System.EventHandler(this.SecuritySetting_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ListView lvUserRoles;
        private System.Windows.Forms.ListView lvAllRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnRemoveRole;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.ToolStripButton toolStripButtonRoleSetting;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddUser;
    }
}