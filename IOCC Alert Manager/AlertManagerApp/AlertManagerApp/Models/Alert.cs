using System;

namespace AlertManagerApp.Models
{
    public class Alert
    {
        public int Id { get; set; }

        public DateTime AlertDT { get; set; }

        public string AlertTypeName { get; set; }

        public int Responses { get; set; }

        public string FacilityName { get; set; }

        public string ReportedBy { get; set; }

        public string FacilityType { get; set; }

        public DateTime FirstViewed { get; set; }
    }
}
