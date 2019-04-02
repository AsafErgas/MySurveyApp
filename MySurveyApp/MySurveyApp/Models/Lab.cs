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
        public float Labweight { get; set; }
        public string Lablocation { get; set; }

        public Lab(string _labId, string _labtopic, DateTime _labdate, int _min, int _max, string _labdetails, string _director, float _labweight, string _lablocation)
        {

            LabId = _labId;
            Labtopic = _labtopic;
            Labdate = _labdate;
            Minperson = _min;
            Maxperson = _max;
            Labdetails = _labdetails;
            Director = _director;
            Labweight = _labweight;
            Lablocation = _lablocation;


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

        public List<Lab> ReadAllLabs()
        {
            DBservices dbs = new DBservices();
            List<Lab> lc = dbs.ReadAllLabs("PersonStringName", "Labs");
            return lc;
        }
    }
}