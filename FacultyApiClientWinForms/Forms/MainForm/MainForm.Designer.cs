namespace FacultyApiClientWinForms.Forms.MainForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.Button();
            this.bDeleteStudent = new System.Windows.Forms.Button();
            this.bAddStudent = new System.Windows.Forms.Button();
            this.bUpdateStudent = new System.Windows.Forms.Button();
            this.tabLectors = new System.Windows.Forms.TabPage();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStudents);
            this.tabControl1.Controls.Add(this.tabLectors);
            this.tabControl1.Controls.Add(this.tabSchedule);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1104, 505);
            this.tabControl1.TabIndex = 3;
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.tableLayoutPanel1);
            this.tabStudents.Location = new System.Drawing.Point(4, 29);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(1096, 472);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Students";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewStudents, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 466);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStudents.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.RowHeadersWidth = 51;
            this.dataGridViewStudents.Size = new System.Drawing.Size(1084, 378);
            this.dataGridViewStudents.TabIndex = 6;
            this.dataGridViewStudents.Text = "dataGridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refresh);
            this.panel1.Controls.Add(this.bDeleteStudent);
            this.panel1.Controls.Add(this.bAddStudent);
            this.panel1.Controls.Add(this.bUpdateStudent);
            this.panel1.Location = new System.Drawing.Point(3, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 76);
            this.panel1.TabIndex = 7;
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.refresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.refresh.Location = new System.Drawing.Point(955, 13);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(103, 49);
            this.refresh.TabIndex = 3;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // bDeleteStudent
            // 
            this.bDeleteStudent.BackColor = System.Drawing.Color.IndianRed;
            this.bDeleteStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bDeleteStudent.ForeColor = System.Drawing.SystemColors.Menu;
            this.bDeleteStudent.Location = new System.Drawing.Point(40, 13);
            this.bDeleteStudent.Name = "bDeleteStudent";
            this.bDeleteStudent.Size = new System.Drawing.Size(184, 49);
            this.bDeleteStudent.TabIndex = 5;
            this.bDeleteStudent.Text = "Delete";
            this.bDeleteStudent.UseVisualStyleBackColor = false;
            this.bDeleteStudent.Click += new System.EventHandler(this.bDeleteStudent_Click);
            // 
            // bAddStudent
            // 
            this.bAddStudent.BackColor = System.Drawing.Color.LightCyan;
            this.bAddStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bAddStudent.Location = new System.Drawing.Point(477, 13);
            this.bAddStudent.Name = "bAddStudent";
            this.bAddStudent.Size = new System.Drawing.Size(184, 49);
            this.bAddStudent.TabIndex = 3;
            this.bAddStudent.Text = "Add";
            this.bAddStudent.UseVisualStyleBackColor = false;
            this.bAddStudent.Click += new System.EventHandler(this.bAddStudent_Click);
            // 
            // bUpdateStudent
            // 
            this.bUpdateStudent.AutoSize = true;
            this.bUpdateStudent.BackColor = System.Drawing.Color.OldLace;
            this.bUpdateStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bUpdateStudent.Location = new System.Drawing.Point(256, 13);
            this.bUpdateStudent.Name = "bUpdateStudent";
            this.bUpdateStudent.Size = new System.Drawing.Size(184, 49);
            this.bUpdateStudent.TabIndex = 4;
            this.bUpdateStudent.Text = "Edit";
            this.bUpdateStudent.UseVisualStyleBackColor = false;
            this.bUpdateStudent.Click += new System.EventHandler(this.bUpdateStudent_Click);
            // 
            // tabLectors
            // 
            this.tabLectors.Location = new System.Drawing.Point(4, 29);
            this.tabLectors.Name = "tabLectors";
            this.tabLectors.Padding = new System.Windows.Forms.Padding(3);
            this.tabLectors.Size = new System.Drawing.Size(1096, 472);
            this.tabLectors.TabIndex = 1;
            this.tabLectors.Text = "Lectors";
            this.tabLectors.UseVisualStyleBackColor = true;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Location = new System.Drawing.Point(4, 29);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(1096, 472);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Schedule";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1104, 505);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabLectors;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.Button bDeleteStudent;
        private System.Windows.Forms.Button bUpdateStudent;
        private System.Windows.Forms.Button bAddStudent;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button refresh;
    }
}

