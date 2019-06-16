using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class Lab
    {
        public string LabId { get; set; }
        public string Labtopic { get; set; }
        public DateTime Labdate { get; set; }
        public int Minperson { get; set; }
        public int Maxperson { get; set; }
        public string Labdetails { get; set; }
        public string Director { get; set; }
        public string LecId { get; set; }
        public float Labweight { get; set; }
        public string Lablocation { get; set; }
        public string Finalcode { get; set; }

        public int Currentnum { get; set; }

        public Lab(string _labId, string _labtopic, DateTime _labdate, int _min, int _max, string _labdetails, string _director,string l, float _labweight, string _lablocation, string fc, int cn)
        {

            LabId = _labId;
            Labtopic = _labtopic;
            Labdate = _labdate;
            Minperson = _min;
            Maxperson = _max;
            Labdetails = _labdetails;
            Director = _director;
            LecId = l;
            Labweight = _labweight;
            Lablocation = _lablocation;
            Finalcode = fc;
            Currentnum = cn;

        }
        public int insertlab()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertlab(this);
            return numAffected;
        }
        public Lab()
        {

        }
        public List<Lab> ReadLabs(string lecId)
        {
            DBservices dbs = new DBservices();
            List<Lab> lc = dbs.ReadLabs("PersonStringName", "Labs", lecId);
            return lc;
        }
        
              public List<Lab> getlabtofinish(string finishcode)
        {
            DBservices dbs = new DBservices();
            List<Lab> lc = dbs.getlabtofinish("PersonStringName", "Labs", finishcode);
            return lc;
        }
        public List<Lab> ReadAllLabs()
        {
            DBservices dbs = new DBservices();
            List<Lab> lc = dbs.ReadAllLabs("PersonStringName", "Labs");
            return lc;
        }
        
            public List<Lab> ReadLabsReport(string lecId)
        {
            DBservices dbs = new DBservices();
            List<Lab> lc = dbs.ReadLabsReport("PersonStringName", "Labs", lecId);
            return lc;
        }
        public int Editlab(string lid)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.Editlab(this, lid);
            return numAffected;
        }
        public int deletelab(string lid)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.deletelab(this, lid);
            return numAffected;
        }
        public List<Lab> validlab()
        {
            DBservices dbs = new DBservices();
            List<Lab> lc = dbs.validlab("PersonStringName", "Labs");
            return lc;
        }
        public List<Lab> ReadRegLab(string un)
        {
            DBservices dbs = new DBservices();
            List<Lab> lc = dbs.ReadRegLab("PersonStringName", "Labs", un);
            return lc;
        }
      
    }
}