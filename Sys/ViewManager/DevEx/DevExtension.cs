using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;

namespace Sys.ViewManager.DevEx
{
    public static class DevExtension
    {

        public static void Load(this DevExpress.XtraEditors.ImageComboBoxEdit combo, ImageList imageList, string[] items)
        {
            combo.Properties.SmallImages = imageList;
            for(int i=0 ; i< items.Length; i++)
            {
                combo.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(items[i], i, i));
            }
        }

        public static void LoadEnum<T>(this DevExpress.XtraEditors.RadioGroup radioGroup) where T : struct
        {
            Type enumType = typeof(T);
            foreach (object ty in Enum.GetValues(enumType))
                radioGroup.Properties.Items.Add(new RadioGroupItem(ty, ty.ToString()));
        }

        public static Enum GetEnum(this DevExpress.XtraEditors.RadioGroup radioGroup) 
        {
            int index = radioGroup.SelectedIndex;

            if (index == -1)
                return null;

            return (Enum)radioGroup.Properties.Items[index].Value;
        }

        public static void SetEnum(this DevExpress.XtraEditors.RadioGroup radioGroup, Enum value)
        {
            int i = 0;
            foreach (RadioGroupItem item in radioGroup.Properties.Items)
            {
                if (value.Equals(item.Value))
                {
                    radioGroup.SelectedIndex = i;
                    break;
                }
                i++;
            }
            return;
        }

        public static void LoadEnumBit<T>(this DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox tyComboBox) where T : struct
        {
            tyComboBox.Items.Clear();
            foreach (KeyValuePair<int, string> ty in Sys.EnumExtension.EnumBitValues(typeof(T)))
            {
                tyComboBox.Items.Add(new ImageComboBoxItem(ty.Value, ty.Key, 0));
            }

        }

        public static void LoadEnum<T>(this DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox tyComboBox) where T : struct
        {
            tyComboBox.Items.Clear();
            foreach (object ty in Enum.GetValues(typeof(T)))
            {
                tyComboBox.Items.Add(new ImageComboBoxItem(ty.ToString(), (int)ty, 0));
            }

        }

        public static StyleFormatCondition StyleFormatBackColor(string expression, Color color)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.BackColor = color;
            styleFormatCondition.Appearance.BackColor2 = color;
            styleFormatCondition.Appearance.Options.UseBackColor = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            return styleFormatCondition;
        }

        public static StyleFormatCondition StyleFormatForeColor(string expression, Color color)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.ForeColor = color;
            styleFormatCondition.Appearance.Options.UseForeColor = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            return styleFormatCondition;
        }

        public static StyleFormatCondition StyleFormatFont(string expression, Font font)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.Font = font;
            styleFormatCondition.Appearance.Options.UseFont = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            return styleFormatCondition;
        }


        public static object EvaluateRowExpression(DevExpress.XtraGrid.Views.Grid.GridView gridView1, DataRowView dataRow, string expression)
        {
            object result = new DevExpress.Data.Filtering.Helpers.ExpressionEvaluator(
                gridView1.DataController.Helper.DescriptorCollection,
                DevExpress.Data.Filtering.CriteriaOperator.Parse(expression)
                ).Evaluate(dataRow);

            return result;
        }
    }
}
