namespace process_demonizator.UI
{
    sealed partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.numMaxRestarts = new System.Windows.Forms.NumericUpDown();
            this.lblMaxRestarts = new System.Windows.Forms.Label();
            this.gbxOtherOptions = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRestarts)).BeginInit();
            this.gbxOtherOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOptions
            // 
            this.gbxOptions.Controls.Add(this.textBox1);
            this.gbxOptions.Controls.Add(this.label1);
            this.gbxOptions.Controls.Add(this.numMaxRestarts);
            this.gbxOptions.Controls.Add(this.lblMaxRestarts);
            this.gbxOptions.Location = new System.Drawing.Point(12, 12);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(356, 76);
            this.gbxOptions.TabIndex = 1;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Check options:";
            // 
            // numMaxRestarts
            // 
            this.numMaxRestarts.Location = new System.Drawing.Point(148, 19);
            this.numMaxRestarts.Name = "numMaxRestarts";
            this.numMaxRestarts.Size = new System.Drawing.Size(202, 20);
            this.numMaxRestarts.TabIndex = 1;
            // 
            // lblMaxRestarts
            // 
            this.lblMaxRestarts.AutoSize = true;
            this.lblMaxRestarts.Location = new System.Drawing.Point(6, 21);
            this.lblMaxRestarts.Name = "lblMaxRestarts";
            this.lblMaxRestarts.Size = new System.Drawing.Size(128, 13);
            this.lblMaxRestarts.TabIndex = 0;
            this.lblMaxRestarts.Text = "Max restarts per. process:";
            // 
            // gbxOtherOptions
            // 
            this.gbxOtherOptions.Controls.Add(this.comboBox1);
            this.gbxOtherOptions.Controls.Add(this.checkBox1);
            this.gbxOtherOptions.Controls.Add(this.label4);
            this.gbxOtherOptions.Location = new System.Drawing.Point(12, 94);
            this.gbxOtherOptions.Name = "gbxOtherOptions";
            this.gbxOtherOptions.Size = new System.Drawing.Size(356, 93);
            this.gbxOtherOptions.TabIndex = 1;
            this.gbxOtherOptions.TabStop = false;
            this.gbxOtherOptions.Text = "Other options:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(148, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(193, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Launch program when system start.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Language:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log Path";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 20);
            this.textBox1.TabIndex = 3;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 228);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbxOtherOptions);
            this.Controls.Add(this.gbxOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "name settings";
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRestarts)).EndInit();
            this.gbxOtherOptions.ResumeLayout(false);
            this.gbxOtherOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxOptions;
        private System.Windows.Forms.NumericUpDown numMaxRestarts;
        private System.Windows.Forms.Label lblMaxRestarts;
        private System.Windows.Forms.GroupBox gbxOtherOptions;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}