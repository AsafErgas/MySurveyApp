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

    public class StudentController : ApiController
    {



        [HttpGet]
        [Route("api/student")]
        public int Get()
        {
            Student s = new Student();
          int M = s.Numofstudent();
            return M;
        }

        [HttpPost]
        [Route("api/student")]
        public void Post([FromBody]Student s)
        {
            s.insertstudent();

        }
        [HttpGet]
        [Route("api/allstudent")]
        public IEnumerable<Student> Get2()
        {
            Student s = new Student();
            List<Student> M = s.ReadStudent();
            return M;
        }

      



    }
}