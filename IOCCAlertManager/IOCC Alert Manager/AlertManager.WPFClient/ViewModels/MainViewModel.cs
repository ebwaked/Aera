using OperationsAlertManager.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Common;

namespace OperationsAlertManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        ObservableCollection<Alert> _criticalAlerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> CriticalAlerts
        {
            get
            {
                return _criticalAlerts;
            }
            set
            {
                if (_criticalAlerts != value)
                {
                    _criticalAlerts = value;
                    OnPropertyChanged("CriticalAlerts");
                }
            }
        }

        ObservableCollection<Alert> _majorAlerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> MajorAlerts
        {
            get
            {
                return _majorAlerts;
            }
            set
            {
                if (_majorAlerts != value)
                {
                    _majorAlerts = value;
                    OnPropertyChanged("MajorAlerts");
                }
            }
        }

        ObservableCollection<Alert> _minorAlerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> MinorAlerts
        {
            get
            {
                return _minorAlerts;
            }
            set
            {
                if (_minorAlerts != value)
                {
                    _minorAlerts = value;
                    OnPropertyChanged("MinorAlerts");
                }
            }
        }

        ObservableCollection<Alert> _warningAlerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> WarningAlerts
        {
            get
            {
                return _warningAlerts;
            }
            set
            {
                if (_warningAlerts != value)
                {
                    _warningAlerts = value;
                    OnPropertyChanged("WarningAlerts");
                }
            }
        }

        ObservableCollection<Alert> _informationAlerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> InformationAlerts
        {
            get
            {
                return _informationAlerts;
            }
            set
            {
                if (_informationAlerts != value)
                {
                    _informationAlerts = value;
                    OnPropertyChanged("InformationAlerts");
                }
            }
        }

        ObservableCollection<Alert> _inProgressAlerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> InProgressAlerts
        {
            get
            {
                return _inProgressAlerts;
            }
            set
            {
                if (_inProgressAlerts != value)
                {
                    _inProgressAlerts = value;
                    OnPropertyChanged("InProgressAlerts");
                }
            }
        }

        ObservableCollection<Alert> _resolvedAlerts = new ObservableCollection<Alert>();
        public ObservableCollection<Alert> ResolvedAlerts
        {
            get
            {
                return _resolvedAlerts;
            }
            set
            {
                if (_resolvedAlerts != value)
                {
                    _resolvedAlerts = value;
                    OnPropertyChanged("ResolvedAlerts");
                }
            }
        }
        #endregion

        // Slower way but may need if we run into UI blocking or crashes from uncaught errors *** V2 ***
        //public NotifyTaskCompletion<ObservableCollection<Alert>> NTCAlerts { get; private set; }

        public MainViewModel()
        {
            CriticalAlerts = new ObservableCollection<Alert>();
            MajorAlerts = new ObservableCollection<Alert>();
            MinorAlerts = new ObservableCollection<Alert>();
            WarningAlerts = new ObservableCollection<Alert>();
            InformationAlerts = new ObservableCollection<Alert>();
            InProgressAlerts = new ObservableCollection<Alert>();
            ResolvedAlerts = new ObservableCollection<Alert>();
            LoadAlertsTaskMethod();

            // Slower way but may need if we run into UI blocking or crashes from uncaught errors - if changed to this change binding on XAML grid to " NTCAlerts.Result " *** V2 ***
            //NTCAlerts = new NotifyTaskCompletion<ObservableCollection<Alert>>(LoadCriticalAlertsTaskMethod());

        }

        private async Task LoadAlertsTaskMethod()
        {
            // TODO -- change from 2 to 1 -- this is just to make sure i am getting info back properly
            CriticalAlerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts/Priority/1", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
            MajorAlerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts/Priority/2", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
            MinorAlerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts/Priority/3", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
            WarningAlerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts/Priority/4", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
            InformationAlerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts/Priority/5", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
            InProgressAlerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts/InProgress", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
            ResolvedAlerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts/Resolved", string.Empty, null, "GET",
                    string.Empty, string.Empty) as ObservableCollection<Alert>;
        }

        // Slower way but may need if we run into UI blocking or crashes from uncaught errors *** V2 ***
        //private async Task<ObservableCollection<Alert>> LoadCriticalAlertsTaskMethod()
        //{
        //    return Alerts = await RestUtility.CallServiceAsync<ObservableCollection<Alert>>("https://localhost:44396/api/Alerts", string.Empty, null, "GET",
        //            string.Empty, string.Empty) as ObservableCollection<Alert>;
        //}
    }
}
