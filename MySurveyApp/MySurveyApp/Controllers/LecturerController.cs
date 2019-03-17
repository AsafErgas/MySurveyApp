using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySurveyApp.Models;

namespace MYSURVEY.Controllers
{

    public class LecturerController : ApiController
    {
        //[HttpPost]
        //[Route("api/student")]
        //// POST api/values
        //public void Post([FromBody] Student s)
        //{
        //    s.insert();

        //}
        //public void Post([FromBody]Person p3 ,int id)
        //{

        //     p3.Update(p3, id);


        //}





        [HttpGet]
        [Route("api/lecturers")]
        public IEnumerable<Lecturer> Get(string UserName, string Password)
        {
            Lecturer s2 = new Lecturer();
            List<Lecturer> LL = s2.Login(UserName, Password);
            return LL;
        }



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