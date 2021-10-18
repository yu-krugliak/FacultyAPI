using System;
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

            dataGridViewStudents.Fill(_client.GetAllStudents());
        }
    }
}
