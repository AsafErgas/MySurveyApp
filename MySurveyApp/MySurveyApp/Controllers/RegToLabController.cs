using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySurveyApp.Models;

namespace MySurveyApp.Controllers
{
    public class RegToLabController : ApiController
    {
        [HttpPost]
        [Route("api/Regtolab")]
        public void Post(string un, string Lid, float wei)
        {
            RegToLab R = new RegToLab();
            R.Regtolab(un,Lid,wei);

        }
        [HttpGet]
        [Route("api/ifuserreg")]
        public IEnumerable<RegToLab> Get(string un,string Lid)
        {
            RegToLab s = new RegToLab();
            List<RegToLab> L = s.ifuserreg(un,Lid);
            return L;
        }



        [HttpPost]
        [Route("api/deletereglab")]
        public void Put2(string un, string Lid)
        {
            RegToLab r = new RegToLab();
            r.deletereglab(un,Lid);

        }
        [HttpGet]
        [Route("api/allRegForRep")]
        public IEnumerable<RegToLab> GetforRep( string Lid)
        {
            RegToLab s = new RegToLab();
            List<RegToLab> L = s.ReadRegStud(Lid);
            return L;
        }
        [HttpPost]
        [Route("api/addstudenttocounter")]
        public void Post2(string lid)
        {
            RegToLab l = new RegToLab();
            l.addstudenttocounter(lid);

        }

    }
}
