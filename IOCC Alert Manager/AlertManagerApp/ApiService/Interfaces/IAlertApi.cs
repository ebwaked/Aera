using AlertManagerApp.Models;
using System.Collections;
using System.Web.Http;

namespace AlertManagerApp
{
    public interface IAlertApi
    {
        // GET api/alerts
        IList GetAlerts();

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
