using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacultyApiClientWinForms.Forms.MainForm;
using Serilog;
using Serilog.Sinks.WinForms;

namespace FacultyApiClientWinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteToSimpleAndRichTextBox()
                .WriteTo.Console()
                .WriteTo.File("logs\\my_log.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
