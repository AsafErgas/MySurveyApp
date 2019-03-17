using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class OpenSurvey
    {
        public string SurveyId { get; set; }
        public string LecturerId { get; set; }
      



        public OpenSurvey(string _surveyid , string _lecturerid)
        {

            SurveyId = _surveyid;
            LecturerId = _lecturerid;
         
        
        }

        public OpenSurvey()
        {

        }

        //public List<OpenSurvey> ReadOpenSurvey(string lecId)
        //{
        //    DBservices dbs = new DBservices();
        //    List<OpenSurvey> lc = dbs.ReadOpenSurvey("PersonStringName", "OpenSurvey",lecId);
        //    return lc;
        //}

        //public int insert()
        //{
        //    DBservices dbs = new DBservices();
        //    int numAffected = dbs.insert(this);
        //    return numAffected;
        //}

        //public void IsActive(int a ,int id  )
        //{
        //    DBservices dbs = new DBservices();
        //    dbs.Update(a,id);
        //}


        //public int Update(Person p , int id)
        //{
        //    DBservices dbs = new DBservices();
        //    int numAffected = dbs.Update(p,id);
        //    return numAffected;
        //}


    }
}