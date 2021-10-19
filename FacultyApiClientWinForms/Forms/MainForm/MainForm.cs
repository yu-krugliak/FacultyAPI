#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacultyApiClientWinForms.Client;
using FacultyApiClientWinForms.Enums;
using FacultyApiClientWinForms.Extensions;
using FacultyApiClientWinForms.Models;
using Serilog;

namespace FacultyApiClientWinForms.Forms.MainForm
{
    public partial class MainForm : Form
    {
        private readonly FacultyClient _client = FacultyClient.Instance;

        public MainForm()
        {
            InitializeComponent();

            var logForm = new SerilogForm();
            logForm.Show();
            Log.Debug("Forms created successfully.!<>:D");

            //dataGridViewStudents.Fill(_client.GetAllStudents());
            this.Shown += OnShown;
        }

        private async void OnShown(object? sender, EventArgs e)
        {
            Enabled = false;
            await Task.Run(()=>
            {
                var students = _client.GetAllStudents() ?? new List<Student>();
                var groups = (_client.GetAllGroups() ?? new List<Group>())
                    .Prepend(new Group { GroupId = -1, Name = "None" }).ToList();

                var lecturers = _client.GetAllLecturers() ?? new List<Lecturer>();
                var subjects = _client.GetAllSubjects() ?? new List<Subject>();

                var lessons = _client.GetAllLessons() ?? new List<Lesson>();

                BeginInvoke(
                    new Action(() =>
                    {
                        dataGridViewStudents.Fill(students);
                        FillStudentsFilter(groups);

                        dataGridViewLecturers.Fill(lecturers);
                        FillLecturersFilter(subjects);

                        dataGridViewLessons.Fill(lessons);
                        FillLessonsFilter(groups);

                        Enabled = true;
                    }));
            });
        }

        private void FillStudentsFilter(List<Group> groups)
        {
            groupsFilterComboBox.DataSource = groups;
            groupsFilterComboBox.DisplayMember = "Name";
            groupsFilterComboBox.ValueMember = "GroupId";

            expelledComboBox.DataSource = new[]
            {
                new { Value = false, Text = "None" },
                new { Value = true, Text = "True" },
                new { Value = false, Text = "False" }
            };
            expelledComboBox.DisplayMember = "Text";
            expelledComboBox.ValueMember = "Value";
        }

        private void FillLecturersFilter(IEnumerable<Subject> subjects)
        {
            subjectComboBox.DataSource = subjects.Prepend(new Subject { SubjectId = -1, Name = "None" }).ToList();
            subjectComboBox.DisplayMember = "Name";
            subjectComboBox.ValueMember = "SubjectId";
        }

        private void FillLessonsFilter(List<Group> groups)
        {
            lessonsGroupsComboBox.DataSource = groups;
            lessonsGroupsComboBox.DisplayMember = "Name";
            lessonsGroupsComboBox.ValueMember = "GroupId";
        }


        private void bDeleteLecturer_Click(object sender, EventArgs e)
        {

        }

        private async void refreshLecturers_Click(object sender, EventArgs e)
        {
            Log.Debug("Refreshing Lecturers list...");

            Enabled = false;

            await Task.Run(() =>
            {
                RunInUI(() =>
                {
                    var secondName = !string.IsNullOrWhiteSpace(lectureSecondNameTextBox.Text)
                        ? lectureSecondNameTextBox.Text
                        : null;

                    var degree = !string.IsNullOrWhiteSpace(degreeTextbox.Text)
                        ? degreeTextbox.Text
                        : null;

                    var subjectId = (int?)subjectComboBox.SelectedValue == -1
                        ? null
                        : (int?)subjectComboBox.SelectedValue;


                    var lecturers = _client.GetAllLecturers(secondName, degree, subjectId);

                    dataGridViewLecturers.Fill(lecturers);

                    Enabled = true;
                });
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void LessonsRefreshButtonClick(object sender, EventArgs e)
        {
            Log.Debug("Refreshing Lessons list...");

            Enabled = false;

            await Task.Run(() =>
            {
                RunInUI(() =>
                {
                    var groupId = (int?)lessonsGroupsComboBox.SelectedValue == -1
                        ? null
                        : (int?)lessonsGroupsComboBox.SelectedValue;


                    var lessons = _client.GetAllLessons(groupId);

                    dataGridViewLessons.Fill(lessons);

                    Enabled = true;
                });
            });
        }
    }
}
