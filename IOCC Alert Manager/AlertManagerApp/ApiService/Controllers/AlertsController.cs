using OperationsAlertManager.Interfaces;
using OperationsAlertManager.Models;
using OperationsAlertManager.Repositories;
using Common;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using System.Linq;

namespace OperationsAlertManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AlertsController : ApiController, IAlertApi
    {
        // TODO
        //public async Task<IHttpActionResult> GetAlerts()
        //{
        //    return Ok(alertArray);
        //}

        // GET api/alerts
        public IList<Alert> GetAlerts()
        {
            List<Alert> result = new List<Alert>();
            try
            {
                var repository = new AlertRepository();
                result = repository.GetAlerts().ToList();
            }
            catch (Exception ex)
            {
                new Logger("Error TODO: " + ex.Message);
                throw;
            }
            return result;
        }

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
    }
}
