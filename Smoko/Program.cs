using Smoko.Presenter;
using Smoko.Properties;
using Smoko.Service;
using Smoko.View;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Smoko
{
    static class Program
    {
        private static Mutex _mutex;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!IsSingleInstance())
            {
                MessageBox.Show(Resources.AppAlreadyRunning, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var view = new SettingsView();
            var communication = new Communication();
            new SmokoPresenter(view, communication);
            Application.Run(view);
        }

        private static bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting(Resources.AppName);
            }
            catch
            {
                _mutex = new Mutex(true, Resources.AppName);
                return true;
            }
            return false;
        }
    }
}
