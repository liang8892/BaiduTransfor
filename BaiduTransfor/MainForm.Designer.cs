namespace BaiduTransfor
{
    partial class MainForm
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
            this.btn_transEn = new System.Windows.Forms.Button();
            this.btn_transZh = new System.Windows.Forms.Button();
            this.tb_input = new System.Windows.Forms.TextBox();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_transEn
            // 
            this.btn_transEn.Location = new System.Drawing.Point(160, 183);
            this.btn_transEn.Name = "btn_transEn";
            this.btn_transEn.Size = new System.Drawing.Size(75, 23);
            this.btn_transEn.TabIndex = 0;
            this.btn_transEn.Text = "en";
            this.btn_transEn.UseVisualStyleBackColor = true;
            this.btn_transEn.Click += new System.EventHandler(this.Transfor);
            // 
            // btn_transZh
            // 
            this.btn_transZh.Location = new System.Drawing.Point(252, 183);
            this.btn_transZh.Name = "btn_transZh";
            this.btn_transZh.Size = new System.Drawing.Size(75, 23);
            this.btn_transZh.TabIndex = 1;
            this.btn_transZh.Text = "zh";
            this.btn_transZh.UseVisualStyleBackColor = true;
            this.btn_transZh.Click += new System.EventHandler(this.Transfor);
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(59, 51);
            this.tb_input.Multiline = true;
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(176, 95);
            this.tb_input.TabIndex = 2;
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(252, 51);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(176, 95);
            this.tb_output.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 249);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.tb_input);
            this.Controls.Add(this.btn_transZh);
            this.Controls.Add(this.btn_transEn);
            this.Name = "MainForm";
            this.Text = "BaiduTransfor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_transEn;
        private System.Windows.Forms.Button btn_transZh;
        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.TextBox tb_output;
    }
}