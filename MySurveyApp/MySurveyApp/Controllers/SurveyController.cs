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
        //[HttpGet]
        //[Route("api/lecturers")]
        //public IEnumerable<Lecturer> Get(string UserName, string Password)
        //{
        //    Lecturer s2 = new Lecturer();
        //    List<Lecturer> LL = s2.Login(UserName, Password);
        //    return LL;
        //}



        ////1-active 0-non active
        //[HttpPut]
        //[Route("api/persons")]
        //public void Put(int Active, int PersonId)
        //{
        //    Person p = new Person();
        //    p.IsActive(Active, PersonId);

        //}



    }
}