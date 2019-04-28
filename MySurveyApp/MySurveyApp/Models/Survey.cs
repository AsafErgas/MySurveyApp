using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class Survey
    {
        public string SurveyId { get; set; }
        public string Topic { get; set; }
        public DateTime Uploaddate { get; set; }
        public DateTime Enddate { get; set; }
        public int Minperson { get; set; }
        public int Maxperson { get; set; }
        public string Details { get; set; }
        public string Auther { get; set; }
        public float Surveyweight { get; set; }
        public string Lecturerid { get; set; }
        public string Link { get; set; }
        public int Isopensurvey { get; set; }
        public int Currentnumofpers { get; set; }




        public Survey(string _surveyid , string _topic, DateTime _upload,DateTime _enddate,int _min,int _max, string _details, string _auther, float _weight , string _lecid, string _link, int _isopen, int _current )
        {

            SurveyId = _surveyid;
            Topic = _topic;
            Uploaddate = _upload;
            Enddate = _enddate;
            Minperson = _min;
            Maxperson = _max;
            Details = _details;
            Auther = _auther;
            Surveyweight = _weight;
            Lecturerid = _lecid;
            Link = _link;
            Isopensurvey = _isopen;
            Currentnumofpers = _current;
        
        }

        public Survey()
        {

        }

        public List<Survey> ReadSurvey(string lecId, int Isopen)
        {
            DBservices dbs = new DBservices();
            List<Survey> lc = dbs.ReadSurvey("PersonStringName", "Survey",lecId, Isopen);
            return lc;
        }

        public List<Survey> ReadopenSurvey(int Isopen)
        {
            DBservices dbs = new DBservices();
            List<Survey> lc = dbs.ReadopenSurvey("PersonStringName", "Survey",  Isopen);
            return lc;
        }

        public List<Survey> ReadAllSurvey(string lecId)
        {
            DBservices dbs = new DBservices();
            List<Survey> lc = dbs.ReadAllSurvey("PersonStringName", "Survey", lecId);
            return lc;
        }
        public List<Survey> validSurvey()
        {
            DBservices dbs = new DBservices();
            List<Survey> lc = dbs.validSurvey("PersonStringName", "Survey");
            return lc;
        }

        public int insertsurvey()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertsurvey(this);
            return numAffected;
        }
        public int Editsurvey(string sid)
       {
            DBservices dbs = new DBservices();
            int numAffected = dbs.Editsurvey(this,sid);
            return numAffected;
        }
        public int deletesurvey(string sid)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.deletesurvey(this, sid);
            return numAffected;
        }


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