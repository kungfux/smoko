using IntercomApp.ViewModel;
using System.Windows;

namespace IntercomApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Invites _invites = new Invites();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _invites;
        }
    }
}
