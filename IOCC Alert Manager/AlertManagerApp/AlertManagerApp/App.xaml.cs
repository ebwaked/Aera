using System.Windows;

namespace AlertManagerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
