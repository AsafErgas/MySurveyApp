using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class Status
    {
        public string Username { get; set; }
        public string SurveyId { get; set; }
        public float Surveyammount { get; set; }
        public float Labsammount { get; set; }
        public string LabId { get; set; }
        public float Sum { get; set; }






        public Status(string _us , string _surveyid,float _sammount ,float _lammount ,string _labid )
        {

            Username = _us;
            SurveyId = _surveyid;
            Surveyammount = _sammount;
            Labsammount = _lammount;
            LabId = _labid;
            Sum = Surveyammount + Labsammount;
        
       
        
        }

        public Status()
        {

        }


        public List<Status> Readstatus()
        {
            DBservices dbs = new DBservices();
            List<Status> lc = dbs.Readstatus("PersonStringName", "studentstatus");
            return lc;
        }

        // public List<Survey> ReadAllSurvey(string lecId)
        // {
        //     DBservices dbs = new DBservices();
        //     List<Survey> lc = dbs.ReadAllSurvey("PersonStringName", "Survey", lecId);
        //     return lc;
        // }

        // public int insertsurvey()
        // {
        //     DBservices dbs = new DBservices();
        //     int numAffected = dbs.insertsurvey(this);
        //     return numAffected;
        // }
        // public int Editsurvey(string sid)
        //{
        //     DBservices dbs = new DBservices();
        //     int numAffected = dbs.Editsurvey(this,sid);
        //     return numAffected;
        // }




    }
}