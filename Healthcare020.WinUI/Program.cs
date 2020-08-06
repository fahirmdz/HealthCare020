using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Forms;
using Healthcare020.WinUI.Forms.KorisnickiNalog;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using NLog;

namespace Healthcare020.WinUI
{
    internal static class Program
    {
        private static string GetLogFilePathString()
        {
            var dateString = DateTime.Now.Date.ToString("u");
            var x=dateString.IndexOf(" ");
            dateString = dateString.Substring(0, x);

            return $"{Resources.LogFilePath.Replace("#", dateString)}";
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                LogManager.GetCurrentClassLogger().Error(ex);
                var logFilePath = GetLogFilePathString();
                if (MessageBox.Show(Resources.ExceptionThrownLogFileWritten.Replace("#",logFilePath).Replace("\\n",Environment.NewLine),
                    "Greška!", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    Process.Start($@"{logFilePath}");
                }
                else
                {

                }

                if (ex is UnauthorizedException)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show("Unhadled domain exception:\n\n" + ex.Message);
                }
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UnhadledExceptionHandler: \n\n"
                                    + exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // It should terminate our main thread so Application.Exit() is unnecessary here
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var culture = CultureInfo.GetCultureInfo("bs-Latn-BA");
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Add handler for UI thread exception
            Application.ThreadException += UIThreadException;

            //Force all WinForms errors to go through handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //This handler is for catching non-UI thread exception
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            using (var reg = Registry.CurrentUser.OpenSubKey(Properties.Settings.Default.RegistryKey))
            {
                if (reg != null)
                {
                    frmLogin.Instance.Login(
                        reg.GetValue(Resources.RegistryKeyValueUsername)?.ToString().Unprotect() ?? string.Empty,
                        reg.GetValue(Resources.RegistryKeyValuePassword)?.ToString().Unprotect() ?? string.Empty, ExternalLoginCall: true);
                    reg.Close();
                }
            }

            Application.Run(MainForm.Instance);
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                LogManager.GetCurrentClassLogger().Error(t.Exception);
                var logFilePath = GetLogFilePathString();

                if (MessageBox.Show(Resources.ExceptionThrownLogFileWritten.Replace("#",logFilePath).Replace("\\n",Environment.NewLine),
                    "Greška!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start(logFilePath);
                }
                else
                {

                }
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal exception happend inside UIThreadException handler",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Here we can decide if we want to end our application or do something else
            Application.Exit();
        }
    }
}