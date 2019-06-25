using OperationsAlertManager.Models;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Http;

namespace OperationsAlertManager.Interfaces
{
    public interface IAlertApi
    {
        // GET api/alerts
        ObservableCollection<Alert> GetAlerts();

        // GET api/alerts/5
        string GetAlert(int id);

        // POST api/alerts
        void PostAlert([FromBody] Alert value);

        // PUT api/alerts/5
        void PutAlert(int id, [FromBody] Alert value);

        // DELETE api/alerts/5
        void DeleteAlert(int id);
    }
}
