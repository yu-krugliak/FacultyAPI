namespace FacultyApiClientWinForms
{
    partial class SerilogForm
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
            this.richTextBoxLogControl1 = new Serilog.Sinks.WinForms.RichTextBoxLogControl();
            this.SuspendLayout();
            // 
            // richTextBoxLogControl1
            // 
            this.richTextBoxLogControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogControl1.ForContext = "";
            this.richTextBoxLogControl1.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLogControl1.Name = "richTextBoxLogControl1";
            this.richTextBoxLogControl1.Size = new System.Drawing.Size(950, 545);
            this.richTextBoxLogControl1.TabIndex = 0;
            this.richTextBoxLogControl1.Text = "";
            // 
            // SerilogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 545);
            this.Controls.Add(this.richTextBoxLogControl1);
            this.Name = "SerilogForm";
            this.Text = "SerilogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Serilog.Sinks.WinForms.RichTextBoxLogControl richTextBoxLogControl1;
    }
}