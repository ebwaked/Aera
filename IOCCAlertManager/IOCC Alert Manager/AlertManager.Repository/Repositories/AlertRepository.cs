using OperationsAlertManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;

namespace OperationsAlertManager.Data.Repositories
{
    public partial class AlertModelContainer
    {
        public AlertModelContainer(string connectionString) : base(connectionString) { }
        
    }

    public class AlertRepository
    {
        private static readonly string _configConnectionString = ConfigurationManager.ConnectionStrings["AlertManagerRespository"].ToString();
        private readonly string _connectionString;

        public Exception RepositoryException { get; set; }

        public AlertRepository()
        {
            if (!string.IsNullOrEmpty(_configConnectionString))
            {
                var entityBuilder = new EntityConnectionStringBuilder
                {
                    Provider = "System.Data.SqlClient",
                    ProviderConnectionString = _configConnectionString,
                    Metadata = ConfigurationManager.ConnectionStrings["AlertManagerEntities"].ConnectionString
                };
                _connectionString = entityBuilder.ToString();
            }
        }

        public IList<Alert> GetAlerts()
        {
            throw new NotImplementedException();
        }

        public IList<Alert> GetPendingAlertsByPriority(int id)
        {
            List<Alert> result = new List<Alert>();
            
            if (string.IsNullOrEmpty(_connectionString)) return result;
            using (var db = new AlertModelContainer(_connectionString))
            {
                result = db.GetPendingAlertsByPriority(id).Select(alrts => new Alert
                {
                    Id = alrts.ALRT_ID,
                    AlertDT = alrts.ALRT_CRE_DTTM,
                    AlertTypeName = alrts.ALRT_TYPE_NME,
                    FacilityName = alrts.FAC_NME,
                    Equipment = alrts.EQPT_ITEM_DESC,
                    SourceSystem = alrts.ALRT_SS_NME,
                    SourceSystemCreateDate = alrts.CRE_DTTM,
                    SourceSystemDetail = alrts.ALRT_SS_DTL_TXT
                }).ToList();
            }
            return result;
        }

        public IList<Alert> GetInProgressAlerts()
        {
            List<Alert> result = new List<Alert>();

            if (string.IsNullOrEmpty(_connectionString)) return result;
            using (var db = new AlertModelContainer(_connectionString))
            {
                result = db.GetInProgressAlerts().Select(alrts => new Alert
                {
                    Id = alrts.ALRT_ID,
                    AlertDT = alrts.ALRT_CRE_DTTM,
                    AlertPriority = alrts.ALRT_PRIO_TYPE_NME,
                    AlertTypeName = alrts.ALRT_TYPE_NME,
                    NumResponses = alrts.RESP_CNT,
                    FacilityName = alrts.FAC_NME,
                    Equipment = alrts.EQPT_ITEM_DESC,
                    SourceSystem = alrts.ALRT_SS_NME,
                    SourceSystemCreateDate = alrts.CRE_DTTM,
                    SourceSystemDetail = alrts.ALRT_SS_DTL_TXT
                }).ToList();
            }
            return result;
        }

        public IList<Alert> GetResolvedAlerts(DateTime dttm)
        {
            List<Alert> result = new List<Alert>();

            if (string.IsNullOrEmpty(_connectionString)) return result;
            using (var db = new AlertModelContainer(_connectionString))
            {
                result = db.GetResolvedAlerts(dttm).Select(alrts => new Alert
                {
                    Id = alrts.ALRT_ID,
                    AlertDT = alrts.ALRT_CRE_DTTM,
                    AlertTypeName = alrts.ALRT_TYPE_NME,
                    FacilityName = "1",//alrts.FAC_NME,
                    Equipment = "2",//alrts.EQPT_ITEM_DESC,
                    SourceSystem = alrts.ALRT_SS_NME,
                    SourceSystemCreateDate = DateTime.Now,//alrts.CRE_DTTM,
                    SourceSystemDetail = alrts.ALRT_SS_DTL_TXT
                }).ToList();
            }
            return result;
        }

    }
}
