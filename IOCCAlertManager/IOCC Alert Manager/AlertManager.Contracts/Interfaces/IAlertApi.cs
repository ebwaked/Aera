using OperationsAlertManager.Models;
using System.Collections.Generic;

namespace OperationsAlertManager.Interfaces
{
    public interface IAlertApi
    {
        // GET api/alerts
        IList<Alert> GetAlerts();

        // GET api/alerts/5
        IList<Alert> GetPendingAlertsByPriority(int id);

        // GET api/alerts/5
        string GetAlert(int id);

        // POST api/alerts
        void PostAlert(Alert value);

        // PUT api/alerts/5
        void PutAlert(int id, Alert value);

        // DELETE api/alerts/5
        void DeleteAlert(int id);
    }
}
