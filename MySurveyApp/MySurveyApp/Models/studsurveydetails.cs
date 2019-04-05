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
      






        public studsurveydetails(string _us ,string _sid ,float _sw )
        {

            Username = _us;

            SurveyId = _sid;
            Surveyweight = _sw;
          
         
        
       
        
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

      




    }
}