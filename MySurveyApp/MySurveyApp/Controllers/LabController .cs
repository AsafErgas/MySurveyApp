using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySurveyApp.Models;

namespace MySurveyApp.Controllers
{
    public class LabController : ApiController
    {
        [HttpPost]
        [Route("api/lab")]
        public void Post([FromBody]Lab l)
        {
            l.insertlab();

        }

        [HttpGet]
        [Route("api/showlab")]
        public IEnumerable<Lab> Get(string lecId)
        {
            Lab s = new Lab();
            List<Lab> L = s.ReadLabs(lecId);
            return L;
        }
        [HttpGet]
        [Route("api/getlabtofinish")]
        public IEnumerable<Lab> Gettofinish(string finishcode)
        {
            Lab s = new Lab();
            List<Lab> L = s.getlabtofinish(finishcode);
            return L;
        }

        [HttpGet]
        [Route("api/allLabs")]
        public IEnumerable<Lab> Get()
        {
            Lab s = new Lab();
            List<Lab> L = s.ReadAllLabs();
            return L;
        }

        [HttpPut]
        [Route("api/editlab")]
        public void Put([FromBody]Lab l, string lid)
        {
            l.Editlab(lid);

        }
        [HttpPut]
        [Route("api/deletelab")]
        public void Put2([FromBody]Lab s, string lid)
        {
            s.deletelab(lid);

        }
        [HttpGet]
        [Route("api/validlab")]
        public IEnumerable<Lab> Get2()
        {
            Lab s = new Lab();
            List<Lab> M = s.validlab();
            return M;
        }
        [HttpGet]
        [Route("api/ReadRegLab")]
        public IEnumerable<Lab> Getreg(string un)
        {
            Lab s = new Lab();
            List<Lab> L = s.ReadRegLab(un);
            return L;
        }
    }
}
