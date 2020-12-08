namespace Value_and_Unit_Text_Converter
{
    partial class value_and_unit_text_Converter_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(value_and_unit_text_Converter_Form));
            this.BTN_val = new System.Windows.Forms.Button();
            this.BTN_convert = new System.Windows.Forms.Button();
            this.TXT_value = new System.Windows.Forms.TextBox();
            this.TXT_lang = new System.Windows.Forms.TextBox();
            this.TXT_unit = new System.Windows.Forms.TextBox();
            this.LBL_result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_val
            // 
            this.BTN_val.Location = new System.Drawing.Point(12, 75);
            this.BTN_val.Name = "BTN_val";
            this.BTN_val.Size = new System.Drawing.Size(244, 25);
            this.BTN_val.TabIndex = 0;
            this.BTN_val.Text = "Validaton";
            this.BTN_val.UseVisualStyleBackColor = true;
            this.BTN_val.Click += new System.EventHandler(this.BTN_val_Click);
            // 
            // BTN_convert
            // 
            this.BTN_convert.Enabled = false;
            this.BTN_convert.Location = new System.Drawing.Point(188, 43);
            this.BTN_convert.Name = "BTN_convert";
            this.BTN_convert.Size = new System.Drawing.Size(68, 27);
            this.BTN_convert.TabIndex = 1;
            this.BTN_convert.Text = "Convert";
            this.BTN_convert.UseVisualStyleBackColor = true;
            this.BTN_convert.Click += new System.EventHandler(this.BTN_convert_Click);
            // 
            // TXT_value
            // 
            this.TXT_value.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_value.Location = new System.Drawing.Point(12, 12);
            this.TXT_value.Name = "TXT_value";
            this.TXT_value.Size = new System.Drawing.Size(244, 26);
            this.TXT_value.TabIndex = 2;
            this.TXT_value.Text = "Value";
            this.TXT_value.TextChanged += new System.EventHandler(this.TXT_value_TextChanged);
            this.TXT_value.Enter += new System.EventHandler(this.TXT_value_Enter);
            this.TXT_value.Leave += new System.EventHandler(this.TXT_value_Leave);
            // 
            // TXT_lang
            // 
            this.TXT_lang.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_lang.Location = new System.Drawing.Point(12, 44);
            this.TXT_lang.Name = "TXT_lang";
            this.TXT_lang.Size = new System.Drawing.Size(81, 26);
            this.TXT_lang.TabIndex = 3;
            this.TXT_lang.Text = "Language";
            this.TXT_lang.TextChanged += new System.EventHandler(this.TXT_lang_TextChanged);
            this.TXT_lang.Enter += new System.EventHandler(this.TXT_lang_Enter);
            this.TXT_lang.Leave += new System.EventHandler(this.TXT_lang_Leave);
            // 
            // TXT_unit
            // 
            this.TXT_unit.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TXT_unit.Location = new System.Drawing.Point(99, 43);
            this.TXT_unit.Name = "TXT_unit";
            this.TXT_unit.Size = new System.Drawing.Size(83, 26);
            this.TXT_unit.TabIndex = 4;
            this.TXT_unit.Text = "Unit";
            this.TXT_unit.TextChanged += new System.EventHandler(this.TXT_unit_TextChanged);
            this.TXT_unit.Enter += new System.EventHandler(this.TXT_unit_Enter);
            this.TXT_unit.Leave += new System.EventHandler(this.TXT_unit_Leave);
            // 
            // LBL_result
            // 
            this.LBL_result.AutoSize = true;
            this.LBL_result.Location = new System.Drawing.Point(12, 153);
            this.LBL_result.Name = "LBL_result";
            this.LBL_result.Size = new System.Drawing.Size(46, 19);
            this.LBL_result.TabIndex = 5;
            this.LBL_result.Text = "Result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 133);
            this.label1.TabIndex = 6;
            this.label1.Text = "Units : \r\nMeter(m)\r\nCentimeter(cm)\r\nMillimeter(mm)\r\nKilogram(kg)\r\nGram(gm)\r\nLiter" +
    "(L)";
            // 
            // value_and_unit_text_Converter_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(384, 192);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_result);
            this.Controls.Add(this.TXT_unit);
            this.Controls.Add(this.TXT_lang);
            this.Controls.Add(this.TXT_value);
            this.Controls.Add(this.BTN_convert);
            this.Controls.Add(this.BTN_val);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "value_and_unit_text_Converter_Form";
            this.Text = "Value of unit Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_val;
        private System.Windows.Forms.Button BTN_convert;
        private System.Windows.Forms.TextBox TXT_value;
        private System.Windows.Forms.TextBox TXT_lang;
        private System.Windows.Forms.TextBox TXT_unit;
        private System.Windows.Forms.Label LBL_result;
        private System.Windows.Forms.Label label1;
    }
}

