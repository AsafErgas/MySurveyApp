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

        [HttpGet]
        [Route("api/ReadstatuslabforApp")]
        public IEnumerable<studlabdetails> Get2(string usern)
        {
            studlabdetails l = new studlabdetails();
            List<studlabdetails> M = l.ReadstatuslabforApp(usern);
            return M;
        }

        [HttpPost]
        [Route("api/insertLabfromApp")]
        public void Post(string un, string Lid,float wei)
        {
            studlabdetails l = new studlabdetails();
            l.insertLabfromApp(un,Lid,wei);

        }
       

        [HttpGet]
        [Route("api/getpresent")]
        public IEnumerable<studlabdetails> Get3(string lid)
        {
            studlabdetails l = new studlabdetails();
            List<studlabdetails> M = l.getpresent(lid);
            return M;
        }







    }
}