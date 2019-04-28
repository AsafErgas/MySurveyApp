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

    public class StatusController : ApiController
    {



        [HttpGet]
        [Route("api/statusstudent")]
        public IEnumerable<Status> Get()
        {
            Status s = new Status();
            List<Status> M = s.Readstatus();
            return M;
        }


        [HttpGet]
        [Route("api/statusspecstudent")]
        public float Get2(string un)
        {
            Status s = new Status();
            float M = s.Readspecstud(un);
            return M;
        }








    }
}