namespace FacultyApiClientWinForms
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bDeleteStudent = new System.Windows.Forms.Button();
            this.bUpdateStudent = new System.Windows.Forms.Button();
            this.bAddStudent = new System.Windows.Forms.Button();
            this.tabLectors = new System.Windows.Forms.TabPage();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStudents);
            this.tabControl1.Controls.Add(this.tabLectors);
            this.tabControl1.Controls.Add(this.tabSchedule);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1018, 509);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.dataGridView1);
            this.tabStudents.Controls.Add(this.bDeleteStudent);
            this.tabStudents.Controls.Add(this.bUpdateStudent);
            this.tabStudents.Controls.Add(this.bAddStudent);
            this.tabStudents.Location = new System.Drawing.Point(4, 29);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(1010, 476);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Students";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(947, 349);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // bDeleteStudent
            // 
            this.bDeleteStudent.BackColor = System.Drawing.Color.IndianRed;
            this.bDeleteStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bDeleteStudent.ForeColor = System.Drawing.SystemColors.Menu;
            this.bDeleteStudent.Location = new System.Drawing.Point(23, 409);
            this.bDeleteStudent.Name = "bDeleteStudent";
            this.bDeleteStudent.Size = new System.Drawing.Size(184, 49);
            this.bDeleteStudent.TabIndex = 5;
            this.bDeleteStudent.Text = "Delete";
            this.bDeleteStudent.UseVisualStyleBackColor = false;
            // 
            // bUpdateStudent
            // 
            this.bUpdateStudent.BackColor = System.Drawing.Color.OldLace;
            this.bUpdateStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bUpdateStudent.Location = new System.Drawing.Point(561, 409);
            this.bUpdateStudent.Name = "bUpdateStudent";
            this.bUpdateStudent.Size = new System.Drawing.Size(184, 49);
            this.bUpdateStudent.TabIndex = 4;
            this.bUpdateStudent.Text = "Edit";
            this.bUpdateStudent.UseVisualStyleBackColor = false;
            // 
            // bAddStudent
            // 
            this.bAddStudent.BackColor = System.Drawing.Color.LightCyan;
            this.bAddStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bAddStudent.Location = new System.Drawing.Point(786, 409);
            this.bAddStudent.Name = "bAddStudent";
            this.bAddStudent.Size = new System.Drawing.Size(184, 49);
            this.bAddStudent.TabIndex = 3;
            this.bAddStudent.Text = "Add";
            this.bAddStudent.UseVisualStyleBackColor = false;
            // 
            // tabLectors
            // 
            this.tabLectors.Location = new System.Drawing.Point(4, 29);
            this.tabLectors.Name = "tabLectors";
            this.tabLectors.Padding = new System.Windows.Forms.Padding(3);
            this.tabLectors.Size = new System.Drawing.Size(1010, 476);
            this.tabLectors.TabIndex = 1;
            this.tabLectors.Text = "Lectors";
            this.tabLectors.UseVisualStyleBackColor = true;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Location = new System.Drawing.Point(4, 29);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(1010, 476);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Schedule";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 533);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

