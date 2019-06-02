using System;
using System.Threading;
using System.Windows;

namespace Smoko
{
    public partial class App : Application
    {
        private const string MUTEX_NAME = "SmokoWpf";
        private static Mutex _mutex = null;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SetDefaultLanguageDictionary();

            if (IsAppAlreadyRunning())
            {
                MessageBox.Show(
                    GetString("MessageAppAlreadyRunning"),
                    GetString("MessageDefaultCaption"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Current.Shutdown();
            }
        }

        private bool IsAppAlreadyRunning()
        {
            _mutex = new Mutex(true, MUTEX_NAME, out bool isCreatedNew);
            return !isCreatedNew;
        }

        public static void SetDefaultLanguageDictionary()
        {
            var dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "ru-RU":
                    dict.Source = new Uri("Properties\\StringResources.ru-RU.xaml", UriKind.Relative);
                    break;
                case "en-US":
                default:
                    dict.Source = new Uri("Properties\\StringResources.en-US.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        public static string GetString(string key)
        {
            return Application.Current.TryFindResource(key)?.ToString();
        }
    }
}
