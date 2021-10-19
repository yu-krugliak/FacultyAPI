using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            var bs = (BindingSource)dataGridViewStudents.DataSource;
            var students = (List<Student>)bs.DataSource;
            students.Add(add.Student);

            dataGridViewStudents.ResetEndEdit();
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

            //MessageBox.Show("Object deleted");
        }

        private async void refresh_Click(object sender, EventArgs e)
        {
            Log.Debug("Refreshing students list...");

            Enabled = false;

            await Task.Run(() =>
            {
                RunInUI(() =>
                {
                    var secondName = !string.IsNullOrEmpty(textBox1.Text) ? textBox1.Text : null;
                    var groupId = (int?)groupsFilterComboBox.SelectedValue == -1
                        ? null
                        : (int?)groupsFilterComboBox.SelectedValue;
                    var expelled = expelledComboBox.SelectedIndex == 0
                        ? null
                        : (bool?)expelledComboBox.SelectedValue;

                    var students = _client.GetAllStudents(secondName, groupId, expelled);

                    dataGridViewStudents.Fill(students);

                    Enabled = true;
                });
            });
        }

        private void RunInUI(Action action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(action);
                return;
            }

            action();
        }
    }
}