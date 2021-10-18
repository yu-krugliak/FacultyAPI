using System;
using System.Windows.Forms;
using FacultyApiClientWinForms.Enums;
using FacultyApiClientWinForms.Extensions;
using FacultyApiClientWinForms.Models;
using Serilog;

namespace FacultyApiClientWinForms.Forms.MainForm
{
    public partial class MainForm
    {
        private void bAddStudent_Click(object sender, EventArgs e)
        {
            var add = new AddStudent();
            add.ShowDialog();
        }

        private void bUpdateStudent_Click(object sender, EventArgs e)
        {
            var student = dataGridViewStudents.GetCurrentRowData<Student>();
            var add = new AddStudent(student, FormType.Update);
            add.ShowDialog();

            dataGridViewStudents.ResetEndEdit();
        }

        private void bDeleteStudent_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void DeleteStudent()
        {
            var index = dataGridViewStudents.CurrentCell.RowIndex;
            var id = dataGridViewStudents.GetCurrentRowData<Student>().StudentId;
            //?? throw new NullReferenceException();

            _client.DeleteStudent(id);
            dataGridViewStudents.Rows.RemoveAt(index);

            MessageBox.Show("Object deleted");
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Log.Debug("Refreshing students list...");
            dataGridViewStudents.Fill(_client.GetAllStudents());
        }
    }
}