using AlertManagerApp.Controllers;
using AlertManagerApp.Models;
using AlertManagerApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

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

            //DataContext = new AlertViewModel();

            dynamic instance = new AlertApiController();

            IList<Alert> listOfAlerts = instance.GetAlerts();

            CollectionViewSource AlertsCollectionCritical = this.Resources["AlertsCollectionCritical"] as CollectionViewSource;
            AlertsCollectionCritical.Source = listOfAlerts;

            CollectionViewSource AlertsCollectionMajor = this.Resources["AlertsCollectionMajor"] as CollectionViewSource;
            AlertsCollectionMajor.Source = listOfAlerts;


            Critical_ID_DS_FilterViewModel vm = new Critical_ID_DS_FilterViewModel();
            this.DataContext = vm;

            //// create a regular ICollectionView  
            //var view = new ListCollectionView(listOfAlerts);

            //// create the ViewFilter class to control the view filter  
            //var filter = new ViewFilter(view);

            //// apply filter expression at any time  
            //filter.FilterExpression = "State = 'PENDING' OR State = 'FAILURE'";

            //// bind view to controls  
            //_listcontrol.ItemsSource = view;
        }

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

        //private void FirstFilter(object sender, FilterEventArgs e)
        //{
        //    //Country c = e.Item as Country;
        //    if (string c != null)
        //    {
        //        e.Accepted = c.Continent.Equals("NA");
        //    }
        //}

        //private void SecondFilter(object sender, FilterEventArgs e)
        //{
        //    Country c = e.Item as Country;
        //    if (c != null)
        //    {
        //        e.Accepted = c.Continent.Equals("EU");
        //    }
        //}

        public class Critical_ID_DS_FilterViewModel
        {
            public IEnumerable<string> Critical_ID_DS { get; set; }

            public Critical_ID_DS_FilterViewModel()
            {
                Critical_ID_DS = new[] { "1", "2", "3" };
            }
        }

        private void Critical_ID_KeyUp(object sender, KeyEventArgs e)
        {
            CollectionView AlertsCollectionCritical = (CollectionView)CollectionViewSource.GetDefaultView(Critical_ID.ItemsSource);

            new Logger("test");

            AlertsCollectionCritical.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(Critical_ID.Text)) return true;
                else
                {
                    if (((string)o).Contains(Critical_ID.Text)) return true;
                    else return false;
                }
            });

            AlertsCollectionCritical.Refresh();

            // if datasource is a DataView, then apply RowFilter as below and replace above logic with below one
            /* 
             DataView view = (DataView) Cmb.ItemsSource; 
             view.RowFilter = ("Name like '*" + Cmb.Text + "*'"); 
            */
        }
    }
}
