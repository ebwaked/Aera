
using AlertManagerApp.Models;
using AlertManagerApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AlertManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Top = 0;
            Left = 0;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.WindowStyle = WindowStyle.ThreeDBorderWindow;

            //getAllAlerts().ContinueWith(() => { return await getAllAlerts() },
            //    TaskScheduler.FromCurrentSynchronizationContext());


            //var listOfAllAlerts = await getAllAlerts();


            //CriticalAlertGV.ItemsSource = listOfAllAlerts;

            // First way to get Data bound
            //DataContext = new AlertViewModel();

            // Second way to bind data with multiple sources on the same page
            //dynamic instance = new AlertApiController();
            //IList<Alert> listOfAlerts = instance.GetAlerts();
            //CollectionViewSource AlertsCollectionCritical = this.Resources["AlertsCollectionCritical"] as CollectionViewSource;
            //AlertsCollectionCritical.Source = listOfAlerts;
            //CollectionViewSource AlertsCollectionMajor = this.Resources["AlertsCollectionMajor"] as CollectionViewSource;
            //AlertsCollectionMajor.Source = listOfAlerts;
        }

        //private async Task SetCriticalAlerts()
        //{
        //    this.CriticalAlertGV.ItemsSource = await getAllAlerts();
        //}

        //static async Task<IList<Alert>> getAllAlerts()
        //{
        //    return IList < Alert > apiAlertsResponse = await RestUtility.CallServiceAsync<IList<Alert>>("https://localhost:44396/api/Alerts", string.Empty, null, "GET",
        //        string.Empty, string.Empty) as IList<Alert>;
        //}

        // First way to get Data bound
        //public class AlertViewModel
        //{
        //    public ICollectionView AlertsCollection { get; }

        //    public AlertViewModel()
        //    {
        //        dynamic instance = new AlertApiController();

        //        IEnumerable<Alert> listOfAlerts = instance.GetAlerts();
        //        AlertsCollection = CollectionViewSource.GetDefaultView(listOfAlerts);
        //    }
        //}

        // third way of data binding
        //internal class DbContext { }


        //public partial class DbContext
        //{
        //    private AlertsCollection _AlertsCollection;
        //    public AlertsCollection AlertsCollection
        //    {
        //        get
        //        {
        //            if (this._AlertsCollection == null)
        //            {
        //                this._AlertsCollection = new AlertsCollection();

        //                System.Uri resourceUri = new Uri()
        //            }
        //        }
        //    }
        //}




        // Used to grab keyup event from combo box
        //private void Critical_ID_KeyUp(object sender, KeyEventArgs e)
        //{
        //    CollectionView AlertsCollectionCritical = (CollectionView)CollectionViewSource.GetDefaultView(Critical_ID.ItemsSource);

        //    new Logger("test");

        //    AlertsCollectionCritical.Filter = ((o) =>
        //    {
        //        if (String.IsNullOrEmpty(Critical_ID.Text)) return true;
        //        else
        //        {
        //            if (((string)o).Contains(Critical_ID.Text)) return true;
        //            else return false;
        //        }
        //    });

        //    AlertsCollectionCritical.Refresh();

        //    // if datasource is a DataView, then apply RowFilter as below and replace above logic with below one
        //    /* 
        //     DataView view = (DataView) Cmb.ItemsSource; 
        //     view.RowFilter = ("Name like '*" + Cmb.Text + "*'"); 
        //    */
        //}
    }



    //public class AlertsCollection : System.Collections.ObjectModel.ObservableCollection<Alert>
    //{

    //}
}
