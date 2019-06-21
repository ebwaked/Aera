using AlertManagerApp.Helpers;
using AlertManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AlertManagerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void ApplicationStart(object sender, StartupEventArgs e)
        {
            IList<Alert> apiAlertsResponse = await RestUtility.CallServiceAsync<IList<Alert>>("https://localhost:44396/api/Alerts", string.Empty, null, "GET",
                    string.Empty, string.Empty) as IList<Alert>;
            MainWindow main = new MainWindow();
            //Window main = MainWindow;
            main.DataContext = apiAlertsResponse;
            main.Show();



        }
        //protected override async void OnStartup(StartupEventArgs e)
        // {

        //  }
    }
}
