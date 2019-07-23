using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class studsurveydetails

    {
        public string Username { get; set; }
      
        public string SurveyId { get; set; }
        public float Surveyweight { get; set; }
        public string Topic { get; set; }
        public string Det { get; set; }





        public studsurveydetails(string _us ,string _sid ,float _sw,string t,string d )
        {

            Username = _us;

            SurveyId = _sid;
            Surveyweight = _sw;
            Topic = t;
            Det = d;
        
       
        
        }

        public studsurveydetails()
        {

        }


        public List<studsurveydetails> Readdetails(string usern)
        {
            DBservices dbs = new DBservices();
            List<studsurveydetails> lc = dbs.Readdetails("PersonStringName", "studentsurveystatus", usern);
            return lc;
        }

        public int uploadsurveyfromapp(string un, string sid, float wei)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.uploadsurveyfromapp(un,sid, wei);
            return numAffected;
        }

        public List<studsurveydetails> checkifsurveyex(string usern, string sid)
        {
            DBservices dbs = new DBservices();
            List<studsurveydetails> lc = dbs.checkifsurveyex("PersonStringName", "studentsurveystatus", usern, sid);
            return lc;
        }




    }
}