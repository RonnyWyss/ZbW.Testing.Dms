using System.Windows;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.Views
{
    /// <summary>
    ///     Interaction logic for SearchView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(string benutzername)
        {
            InitializeComponent();
            DataContext = new MainViewModel(benutzername);
        }
    }
}