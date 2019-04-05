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

    public class studsurveydetailsController : ApiController
    {



        [HttpGet]
        [Route("api/allsurveydetails")]
        public IEnumerable<studsurveydetails> Get(string usern)
        {
            studsurveydetails s = new studsurveydetails();
            List<studsurveydetails> M = s.Readdetails(usern);
            return M;
        }

       









    }
}