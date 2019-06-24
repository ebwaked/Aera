using AlertManagerApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Common;

namespace AlertManagerApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        ObservableCollection<Alert> _alerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> Alerts
        {
            get
            {
                return _alerts;
            }
            set
            {
                if (_alerts != value)
                {
                    _alerts = value;
                    OnPropertyChanged("Alerts");
                }
            }
        }

        public MainViewModel()
        {
            this.Alerts = new ObservableCollection<Alert>();

            //for (int x = 1; x <= 500; x++)
            //{
            //    var dc = new Alert();
            //    dc.Id = x;
            //    dc.AlertDT = DateTime.Today.AddDays(x);
            //    dc.AlertTypeName = "Alert Type Name " + x.ToString();
            //    dc.Responses = x + 1;
            //    dc.FacilityName = x % 2 == 0 ?
            //        "Super Company " + x.ToString() : "Sub-par company " + x.ToString();
            //    dc.ReportedBy = "Reported Name " + x.ToString();
            //    dc.FacilityType = "Facility Type " + x.ToString();
            //    dc.FirstViewed = DateTime.Today.AddDays(x + 2);
            //    Alerts.Add(dc);
            //}

            // TODO - make async?? 
            LoadCriticalAlertsTaskMethod();
        }

        private async Task LoadCriticalAlertsTaskMethod()
        {
            Alerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
        }
    }
}
