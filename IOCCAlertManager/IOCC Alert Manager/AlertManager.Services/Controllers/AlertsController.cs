using OperationsAlertManager.Data.Repositories;
using OperationsAlertManager.Interfaces;
using OperationsAlertManager.Models;
using Common;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using System.Linq;

namespace OperationsAlertManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[RoutePrefix("api/alerts")]
    public class AlertsController : ApiController, IAlertApi
    {
        // GET api/alerts
        //[Route("")]
        public IList<Alert> GetAlerts()
        {
            List<Alert> result = new List<Alert>();
            try
            {
                //throw new Exception("Test");
                var repository = new AlertRepository();
                result = repository.GetAlerts().ToList();
            }
            catch (Exception ex)
            {
                new Logger("Error in AlertsController - GetAlerts(): " + ex.Message, ex);
                throw;
            }
            return result;
        }

        // GET api/alerts/priority/5
        [Route("api/alerts/priority/{id:int}")]
        public IList<Alert> GetPendingAlertsByPriority(int id)
        {
            List<Alert> result = new List<Alert>();
            try
            {
                throw new Exception("Test");
                var repository = new AlertRepository();
                result = repository.GetPendingAlertsByPriority(id).ToList();
            }
            catch (Exception ex)
            {
                new Logger("Error in AlertsController - GetAlerts(): " + ex.Message, ex);
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
