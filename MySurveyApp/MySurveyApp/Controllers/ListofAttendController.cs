﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySurveyApp.Models;

namespace MySurveyApp.Controllers
{
    public class ListofAttendController : ApiController
    {
        [HttpPost]
        [Route("api/ListofAttend")]
        public void Post(string Lid,string un,DateTime LD, string fc)
        {
            ListofAttend l = new ListofAttend();
            l.insertListofAttend(Lid,un,LD,fc);

        }

       
    }
}
