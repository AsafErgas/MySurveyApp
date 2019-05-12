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


        [HttpPost]
        [Route("api/insertsurveyfromapp")]
        public void Post(string un, string sid, float wei)
        {
            studsurveydetails s = new studsurveydetails();
            s.uploadsurveyfromapp(un, sid, wei);

        }



        [HttpGet]
        [Route("api/checkifsurveyex")]
        public IEnumerable<studsurveydetails> Get2(string usern,string sid)
        {
            studsurveydetails s = new studsurveydetails();
            List<studsurveydetails> M = s.checkifsurveyex(usern,sid);
            return M;
        }




    }
}