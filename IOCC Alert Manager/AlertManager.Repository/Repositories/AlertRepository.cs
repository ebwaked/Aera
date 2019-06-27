using OperationsAlertManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;

namespace OperationsAlertManager.Repositories
{
    public partial class AlertEntities : DbContext
    {
        public AlertEntities(string connectionString) : base(connectionString) { }
    }

    public class AlertRepository
    {
        private static readonly string _configConnectionString = ConfigurationManager.ConnectionStrings["AlertManagerRespository"].ToString();
        private readonly string _connectionString;

        public Exception RepositoryException { get; set; }

        public AlertRepository()
        {
            // TODO - uncomment when connecting to DB's (SIDE NOTE!!! FIND OUT WHY VAR ENTITYBUILDER KEEPS FAILING!!)
            //if (!string.IsNullOrEmpty(_configConnectionString))
            //{
            //    var entityBuilder = new EntityConnectionStringBuilder
            //    {
            //        Provider = "System.Data.SqlClient",
            //        ProviderConnectionString = _configConnectionString,
            //        Metadata = ConfigurationManager.ConnectionStrings["GoWebEntities"].ConnectionString
            //    };
            //    _connectionString = entityBuilder.ToString();
            //}
        }

        public IList<Alert> GetAlerts()
        {
            List<Alert> result = new List<Alert>();

            for (int x = 1; x <= 500; x++)
            {
                var dc = new Alert();
                dc.Id = x;
                dc.AlertDT = DateTime.Today.AddDays(x);
                dc.AlertTypeName = "Alert Type Name " + x.ToString();
                dc.Responses = x + 1;
                dc.FacilityName = x % 2 == 0 ?
                    "Super Company " + x.ToString() : "Sub-par company " + x.ToString();
                dc.ReportedBy = "Reported Name " + x.ToString();
                dc.FacilityType = "Facility Type " + x.ToString();
                dc.FirstViewed = DateTime.Today.AddDays(x + 2);
                result.Add(dc);
            }
            // TODO - Connect to database, uncomment and create stored proc in db called GetAlerts that will map to the object explorer and you can call db.GetAlerts()
            //if (string.IsNullOrEmpty(_connectionString)) return result;
            //using (var db = new AlertEntities(_connectionString))
            //{
            //    result = db.GetAlerts().Select(alrts => new Alert
            //    {
            //        Id = alrts.Id,
            //        AlertDT = alrts.AlertDT,
            //        AlertTypeName = alrts.AlertTypeName,
            //        Responses = alrts.Responses,
            //        FacilityName = alrts.FacilityName,
            //        ReportedBy = alrts.ReportedBy,
            //        FacilityType = alrts.FacilityType,
            //        FirstViewed = alrts.FirstViewed
            //    }).ToList();
            //}
            return result;
        }

    }
}
