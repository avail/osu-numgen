namespace NumberGeneratorOsu
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._fontTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._checkBox2x = new System.Windows.Forms.CheckBox();
            this._buttonGenerate = new System.Windows.Forms.Button();
            this._buttonBrowse = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this._buttonColor = new System.Windows.Forms.Button();
            this._comboBoxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _fontTextBox
            // 
            this._fontTextBox.Enabled = false;
            this._fontTextBox.Location = new System.Drawing.Point(56, 48);
            this._fontTextBox.Name = "_fontTextBox";
            this._fontTextBox.Size = new System.Drawing.Size(121, 20);
            this._fontTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Font:";
            // 
            // _checkBox2x
            // 
            this._checkBox2x.AutoSize = true;
            this._checkBox2x.Location = new System.Drawing.Point(56, 74);
            this._checkBox2x.Name = "_checkBox2x";
            this._checkBox2x.Size = new System.Drawing.Size(93, 17);
            this._checkBox2x.TabIndex = 2;
            this._checkBox2x.Text = "generate @2x";
            this._checkBox2x.UseVisualStyleBackColor = true;
            // 
            // _buttonGenerate
            // 
            this._buttonGenerate.Location = new System.Drawing.Point(264, 20);
            this._buttonGenerate.Name = "_buttonGenerate";
            this._buttonGenerate.Size = new System.Drawing.Size(75, 49);
            this._buttonGenerate.TabIndex = 3;
            this._buttonGenerate.Text = "GENERATE";
            this._buttonGenerate.UseVisualStyleBackColor = true;
            this._buttonGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // _buttonBrowse
            // 
            this._buttonBrowse.Location = new System.Drawing.Point(183, 46);
            this._buttonBrowse.Name = "_buttonBrowse";
            this._buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this._buttonBrowse.TabIndex = 4;
            this._buttonBrowse.Text = "Browse";
            this._buttonBrowse.UseVisualStyleBackColor = true;
            this._buttonBrowse.Click += new System.EventHandler(this.button2_Click);
            // 
            // _buttonColor
            // 
            this._buttonColor.Location = new System.Drawing.Point(183, 20);
            this._buttonColor.Name = "_buttonColor";
            this._buttonColor.Size = new System.Drawing.Size(75, 23);
            this._buttonColor.TabIndex = 5;
            this._buttonColor.Text = "Color";
            this._buttonColor.UseVisualStyleBackColor = true;
            this._buttonColor.Click += new System.EventHandler(this.button3_Click);
            // 
            // _comboBoxType
            // 
            this._comboBoxType.FormattingEnabled = true;
            this._comboBoxType.Items.AddRange(new object[] {
            "Default",
            "Score"});
            this._comboBoxType.Location = new System.Drawing.Point(56, 21);
            this._comboBoxType.Name = "_comboBoxType";
            this._comboBoxType.Size = new System.Drawing.Size(121, 21);
            this._comboBoxType.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 102);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._comboBoxType);
            this.Controls.Add(this._buttonColor);
            this.Controls.Add(this._buttonBrowse);
            this.Controls.Add(this._buttonGenerate);
            this.Controls.Add(this._checkBox2x);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._fontTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "osu!numgen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _fontTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _checkBox2x;
        private System.Windows.Forms.Button _buttonGenerate;
        private System.Windows.Forms.Button _buttonBrowse;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button _buttonColor;
        private System.Windows.Forms.ComboBox _comboBoxType;
        private System.Windows.Forms.Label label2;
    }
}

