using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OperationsAlertManager.Models
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
        private string alertPriority;
        private string alertTypeName;
        private DateTime resolvedDT;
        private string resolutionType;
        private string resolvedBy;
        private int numResponses;
        private string facilityName;
        private string equipment;
        private string sourceSystem;
        private DateTime sourceSystemCreateDate;
        private string sourceSystemDetail;
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

        public string AlertPriority
        {
            get { return alertPriority; }
            set
            {
                if (value != this.alertPriority)
                {
                    alertPriority = value;
                    NotifyPropertChanged("AlertPriority");
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

        public DateTime ResolvedDT
        {
            get { return resolvedDT; }
            set
            {
                if (value != this.resolvedDT)
                {
                    resolvedDT = value;
                    NotifyPropertChanged("ResolvedDT");
                }
            }
        }

        public string ResolutionType
        {
            get { return resolutionType; }
            set
            {
                if (value != this.resolutionType)
                {
                    resolutionType = value;
                    NotifyPropertChanged("ResolutionType");
                }
            }
        }

        public string ResolvedBy
        {
            get { return resolvedBy; }
            set
            {
                if (value != this.resolvedBy)
                {
                    resolvedBy = value;
                    NotifyPropertChanged("ResolvedBy");
                }
            }
        }

        public int NumResponses
        {
            get { return numResponses; }
            set
            {
                if (value != this.numResponses)
                {
                    numResponses = value;
                    NotifyPropertChanged("NumResponses");
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

        public string Equipment
        {
            get { return equipment; }
            set
            {
                if (value != this.equipment)
                {
                    equipment = value;
                    NotifyPropertChanged("Equipment");
                }
            }
        }

        public string SourceSystem
        {
            get { return sourceSystem; }
            set
            {
                if (value != this.sourceSystem)
                {
                    sourceSystem = value;
                    NotifyPropertChanged("SourceSystem");
                }
            }
        }

        public DateTime SourceSystemCreateDate
        {
            get { return sourceSystemCreateDate; }
            set
            {
                if (value != this.sourceSystemCreateDate)
                {
                    sourceSystemCreateDate = value;
                    NotifyPropertChanged("SourceSystemCreateDate");
                }
            }
        }

        public string SourceSystemDetail
        {
            get { return sourceSystemDetail; }
            set
            {
                if (value != this.sourceSystemDetail)
                {
                    sourceSystemDetail = value;
                    NotifyPropertChanged("SourceSystemDetail");
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
