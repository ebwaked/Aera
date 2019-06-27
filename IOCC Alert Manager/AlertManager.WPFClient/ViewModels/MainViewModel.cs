using OperationsAlertManager.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Common;

namespace OperationsAlertManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // TODO can i removed lines 12-27
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

        //public NotifyTaskCompletion<ObservableCollection<Alert>> NTCAlerts { get; private set; }
        
        public MainViewModel()
        {
            Alerts = new ObservableCollection<Alert>();
            LoadCriticalAlertsTaskMethod();

            // Slower way but may need if we run into UI blocking or crashes from uncaught errors - if changed to this change binding on XAML grid to " NTCAlerts.Result "
            //NTCAlerts = new NotifyTaskCompletion<ObservableCollection<Alert>>(LoadCriticalAlertsTaskMethod());

        }

        private async Task LoadCriticalAlertsTaskMethod()
        {
            Alerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
        }

        // Slower way but may need if we run into UI blocking or crashes from uncaught errors
        //private async Task<ObservableCollection<Alert>> LoadCriticalAlertsTaskMethod()
        //{
        //    return Alerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts", string.Empty, null, "GET",
        //            string.Empty, string.Empty) as ObservableCollection<Alert>;
        //}
    }
}
