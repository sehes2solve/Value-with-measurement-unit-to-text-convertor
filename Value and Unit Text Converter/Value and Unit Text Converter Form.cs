using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Value_and_Unit_Text_Converter
{
    public partial class value_and_unit_text_Converter_Form : Form
    {
        public value_and_unit_text_Converter_Form()
        {
            InitializeComponent();
        }
        Value_and_Unit_Text__Converter_Methodes Value_and_Unit_Text__Converter_MethodesOBJ = new Value_and_Unit_Text__Converter_Methodes();
        private void TXT_value_Enter(object sender, EventArgs e)
        {
            if(TXT_value.Text == "Value" && TXT_value.ForeColor == SystemColors.InactiveCaption)
            {
                TXT_value.Text = "";
                TXT_value.ForeColor = SystemColors.ActiveCaptionText;
            }
        }

        private void TXT_lang_Enter(object sender, EventArgs e)
        {
            if (TXT_lang.Text == "Language" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
            {
                TXT_lang.Text = "";
                TXT_lang.ForeColor = SystemColors.ActiveCaptionText;
            }
        }

        private void TXT_unit_Enter(object sender, EventArgs e)
        {
            if (TXT_unit.Text == "Unit" && TXT_unit.ForeColor == SystemColors.InactiveCaption)
            {
                TXT_unit.Text = "";
                TXT_unit.ForeColor = SystemColors.ActiveCaptionText;
            }
        }

        private void TXT_value_Leave(object sender, EventArgs e)
        {
            if (TXT_value.Text == "" && TXT_value.ForeColor == SystemColors.ActiveCaptionText)
            {
                TXT_value.Text = "Value";
                TXT_value.ForeColor = SystemColors.InactiveCaption;
            }
        }
 
        private void TXT_lang_Leave(object sender, EventArgs e)
        {
            if (TXT_lang.Text == "" && TXT_lang.ForeColor == SystemColors.ActiveCaptionText)
            {
                TXT_lang.Text = "Language";
                TXT_lang.ForeColor = SystemColors.InactiveCaption;
            }
        }

        private void TXT_unit_Leave(object sender, EventArgs e)
        {
            if (TXT_unit.Text == "" && TXT_unit.ForeColor == SystemColors.ActiveCaptionText)
            {
                TXT_unit.Text = "Unit";
                TXT_unit.ForeColor = SystemColors.InactiveCaption;
            }
        }

        private void BTN_val_Click(object sender, EventArgs e)
        {
            int err_id;
            string err_message;
            if (TXT_value.Text == "Value" && TXT_value.ForeColor == SystemColors.InactiveCaption)
                TXT_value.Text = "";
            if (TXT_lang.Text == "Language" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
                TXT_lang.Text = "";
            if (TXT_unit.Text == "Unit" && TXT_unit.ForeColor == SystemColors.InactiveCaption)
                TXT_unit.Text = "";
            if (Value_and_Unit_Text__Converter_MethodesOBJ.Validation(TXT_value.Text, TXT_lang.Text, TXT_unit.Text, out err_id, out err_message))
                BTN_convert.Enabled = true;
            if (TXT_value.Text == "" && TXT_value.ForeColor == SystemColors.InactiveCaption)
                TXT_value.Text = "Value";
            if (TXT_lang.Text == "" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
                TXT_lang.Text = "Language";
            if (TXT_unit.Text == "" && TXT_unit.ForeColor == SystemColors.InactiveCaption)
                TXT_unit.Text = "Unit";
            LBL_result.Text = err_id + " : " + err_message;
        }

        private void TXT_value_TextChanged(object sender, EventArgs e)
        {
            BTN_convert.Enabled = false;
            LBL_result.Text = "Result";
        }

        private void TXT_lang_TextChanged(object sender, EventArgs e)
        {
            BTN_convert.Enabled = false;
            LBL_result.Text = "Result";
        }

        private void TXT_unit_TextChanged(object sender, EventArgs e)
        {
            BTN_convert.Enabled = false;
            LBL_result.Text = "Result";
        }

        private void BTN_convert_Click(object sender, EventArgs e)
        {
            string temp;
            if (TXT_value.Text == "Value" && TXT_value.ForeColor == SystemColors.InactiveCaption)
                TXT_value.Text = "";
            if (TXT_lang.Text == "Language" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
                TXT_lang.Text = "";
            if (TXT_unit.Text == "Unit" && TXT_unit.ForeColor == SystemColors.InactiveCaption)
                TXT_unit.Text = "";
           temp = Value_and_Unit_Text__Converter_MethodesOBJ.UnitValueTextConverter(TXT_value.Text,TXT_lang.Text,TXT_unit.Text);
            if (TXT_value.Text == "" && TXT_value.ForeColor == SystemColors.InactiveCaption)
                TXT_value.Text = "Value";
            if (TXT_lang.Text == "" && TXT_lang.ForeColor == SystemColors.InactiveCaption)
                TXT_lang.Text = "Language";
            if (TXT_unit.Text == "" && TXT_unit.ForeColor == SystemColors.InactiveCaption)
                TXT_unit.Text = "Unit";
            LBL_result.Text = temp;
        }
    }
}
