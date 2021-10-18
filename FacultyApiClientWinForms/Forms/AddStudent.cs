using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FacultyApiClientWinForms.Client;
using FacultyApiClientWinForms.Enums;
using FacultyApiClientWinForms.Extensions;
using FacultyApiClientWinForms.Models;

namespace FacultyApiClientWinForms.Forms
{
    public partial class AddStudent : Form
    {
        private readonly FacultyClient _client = FacultyClient.Instance;
        private readonly FormType _formType;
        private readonly Student _student;

        public AddStudent() : this(new Student(), FormType.Add) {}

        public AddStudent(Student student, FormType formType)
        {
            InitializeComponent();

            _formType = formType;
            _student = student;

            textStudentId.Text = student.StudentId.ToString();
            textSecondName.Text = student.SecondName;
            textFirstName.Text = student.FirstName;
            textMiddleName.Text = student.MiddleName;
            textYearEntry.Text = student.YearEntry.ToString();
            textPhoneNumber.Text = student.PhoneNumber;
            textExpelled.Text = student.Expelled.ToString();

            var groups = _client.GetAllGroups();
            comboBoxGroups.DataSource = groups;
            comboBoxGroups.DisplayMember = "Name";
            comboBoxGroups.ValueMember = "GroupId";
            comboBoxGroups.SelectedValue = student.GroupId;

            var educations = _client.GetAllEducations();
            comboBoxEducation.DataSource = educations;
            comboBoxEducation.DisplayMember = "Name";
            comboBoxEducation.ValueMember = "EducationTypeId";
            comboBoxEducation.SelectedValue = student.EducationTypeId;

            textStudentId.Validating += TextStudentIdOnValidating;
            textYearEntry.Validating += TextYearEntryOnValidating;
        }

        private void TextYearEntryOnValidating(object sender, CancelEventArgs e)
        {
            if (DateTime.TryParse(textYearEntry.Text, out var value))
            {
                errorProvider1.SetError(textYearEntry, "");
                return;
            }

            errorProvider1.SetError(textYearEntry, "Ne data!");
            e.Cancel = true;
        }

        private void TextStudentIdOnValidating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(textStudentId.Text, out var value))
            {
                errorProvider1.SetError(textStudentId, "");
                return;
            }

            errorProvider1.SetError(textStudentId, "Ne chislo");
            e.Cancel = true;
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            _student.StudentId = int.Parse(textStudentId.Text);
            _student.SecondName = textSecondName.Text;
            _student.FirstName = textFirstName.Text;
            _student.MiddleName = textMiddleName.Text;
            _student.YearEntry = DateTime.Parse(textYearEntry.Text);
            _student.PhoneNumber = textPhoneNumber.Text;
            _student.Expelled = bool.Parse(textExpelled.Text);
            _student.GroupId = (int)comboBoxGroups.SelectedValue;
            _student.EducationTypeId = (int)comboBoxEducation.SelectedValue;

            switch (_formType)
            {
                case FormType.Add:
                    _client.AddStudent(_student);
                    break;
                case FormType.Update:
                    _client.UpdateStudent(_student);
                    break;
            }
            Close();
        }
        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
