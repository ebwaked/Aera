using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AlertManagerApp.Models
{
    public class Alert : INotifyPropertyChanged
    {
        // TODO - make Observable Object base class for implementing INotifyPopertyChanged (ie. the class will become { public class Alert : ObservableObject } -- no longer will need to put this in all classes "#region INotifyPropertyChanged Members"
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion 

        #region Private Properties

        private int id;
        private DateTime alertDT;
        private string alertTypeName;
        private int responses;
        private string facilityName;
        private string reportedBy;
        private string facilityType;
        private DateTime firstViewed;
        private ObservableCollection<Alert> alerts;

        #endregion

        public int Id
        {
            get { return id; }
            set
            {
                if (value != this.id)
                {
                    id = value;
                    NotifyPropertChanged("Id");
                }
            }
        }
        
        public DateTime AlertDT
        {
            get { return alertDT; }
            set
            {
                if (value != this.alertDT)
                {
                    alertDT = value;
                    NotifyPropertChanged("AlertDT");
                }
            }
        }

        public string AlertTypeName
        {
            get { return alertTypeName; }
            set
            {
                if (value != this.alertTypeName)
                {
                    alertTypeName = value;
                    NotifyPropertChanged("AlertTypeName");
                }
            }
        }

        public int Responses
        {
            get { return responses; }
            set
            {
                if (value != this.responses)
                {
                    responses = value;
                    NotifyPropertChanged("Responses");
                }
            }
        }

        public string FacilityName
        {
            get { return facilityName; }
            set
            {
                if (value != this.facilityName)
                {
                    facilityName = value;
                    NotifyPropertChanged("FacilityName");
                }
            }
        }

        public string ReportedBy
        {
            get { return reportedBy; }
            set
            {
                if (value != this.reportedBy)
                {
                    reportedBy = value;
                    NotifyPropertChanged("ReportedBy");
                }
            }
        }

        public string FacilityType
        {
            get { return facilityType; }
            set
            {
                if (value != this.facilityType)
                {
                    facilityType = value;
                    NotifyPropertChanged("FacilityType");
                }
            }
        }

        public DateTime FirstViewed
        {
            get { return firstViewed; }
            set
            {
                if (value != this.firstViewed)
                {
                    firstViewed = value;
                    NotifyPropertChanged("FirstViewed");
                }
            }
        }
        
        public ObservableCollection<Alert> Alerts
        {
            get { return alerts; }
            set
            {
                if (value != this.alerts)
                {
                    alerts = value;
                    NotifyPropertChanged("Alerts");
                }
            }
        }
    }

}
