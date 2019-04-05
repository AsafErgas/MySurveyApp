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

    public class studlabdetailsController : ApiController
    {



        [HttpGet]
        [Route("api/alllabsdetails")]
        public IEnumerable<studlabdetails> Get(string usern)
        {
            studlabdetails s = new studlabdetails();
            List<studlabdetails> M = s.Readdetails2(usern);
            return M;
        }

       









    }
}