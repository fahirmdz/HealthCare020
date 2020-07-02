using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Forms;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using NLog;

namespace Healthcare020.WinUI
{
    internal static class Program
    {
        private static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;

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
                    Auth.AuthenticateWithPassword(reg.GetValue(Resources.RegistryKeyValueUsername)?.ToString().Unprotect() ?? string.Empty,
                        reg.GetValue(Resources.RegistryKeyValuePassword)?.ToString().Unprotect() ?? string.Empty).Wait();
                    reg.Close();
                }
            }
           

            Application.Run(MainForm.Instance);
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                MessageBox.Show("Unhandled exception catched.\n Application is going to close now.");
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