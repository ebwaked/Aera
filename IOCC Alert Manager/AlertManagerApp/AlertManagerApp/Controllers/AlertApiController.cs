using AlertManagerApp.Models;
using System;
using System.Collections;
using System.Web.Http;

namespace AlertManagerApp.Controllers
{
    public class AlertApiController : ApiController, IAlertApi
    {

        // GET api/alerts
        public IList GetAlerts()
        {
            return new Alert[] { alert1, alert2 };
        }

        // TODO
        //public async Task<IHttpActionResult> GetAlerts()
        //{
        //    Alert[] alertArray = new Alert[] { alert1, alert2 };

        //    return Ok(alertArray);
        //}

        // GET api/alerts/5
        public string GetAlert(int id)
        {
            return "value";
        }

        // POST api/alerts
        public void PostAlert([FromBody] Alert value)
        {
            throw new System.NotImplementedException();
        }

        // PUT api/alerts/5
        public void PutAlert(int id, [FromBody] Alert value)
        {
            throw new System.NotImplementedException();
        }

        // DELETE api/alerts/5
        public void DeleteAlert(int id)
        {
            throw new System.NotImplementedException();
        }

        Alert alert1 = new Alert
        {
            Id = 1,
            AlertDT = new DateTime(2019, 02, 28),
            AlertTypeName = "test1",
            Responses = 2,
            FacilityName = "test1",
            ReportedBy = "test1",
            FacilityType = "test1",
            FirstViewed = new DateTime(2019, 03, 11)
        };
        Alert alert2 = new Alert
        {
            Id = 2,
            AlertDT = new DateTime(2019, 03, 22),
            AlertTypeName = "test2",
            Responses = 4,
            FacilityName = "test2",
            ReportedBy = "test2",
            FacilityType = "test2",
            FirstViewed = new DateTime(2019, 04, 07)
        };
    }
}
