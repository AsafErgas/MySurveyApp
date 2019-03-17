using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySurveyApp.Models;

namespace MySurveyApp.Controllers
{

    public class SurveyController : ApiController
    {
        


        [HttpGet]
        [Route("api/survey")]
        public IEnumerable<Survey> Get(string lecId, int Isopen)
        {
            Survey s = new Survey();
            List<Survey> M = s.ReadSurvey(lecId, Isopen);
            return M;
        }

        [HttpGet]
        [Route("api/allsurvey")]
        public IEnumerable<Survey> Get(string lecId)
        {
            Survey s = new Survey();
            List<Survey> M = s.ReadAllSurvey(lecId);
            return M;
        }

        [HttpPost]
        [Route("api/survey")]
        public void Post([FromBody]Survey s)
        {
            s.insertsurvey();

        }

        [HttpPut]
        [Route("api/editsurvey")]
        public void Put([FromBody]Survey s, string sid)
        {
            s.Editsurvey(sid);

        }
  
    }
}