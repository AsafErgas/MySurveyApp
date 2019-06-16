using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class ListofAttend
    {
        public string LabId { get; set; }
        public string Username { get; set; }
        public DateTime Labdate { get; set; }
        public string Finalcode { get; set; }


        public ListofAttend(string _labId, string un, DateTime _labdate, string fc)
        {

            LabId = _labId;
            Username = un;
            Labdate = _labdate;
            Finalcode = fc;

        }
        public int insertListofAttend(string Lid, string un, DateTime LD, string fc)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertListofAttend(Lid, un, LD, fc);
            return numAffected;
        }
        public ListofAttend()
        {

        }
        public List<ListofAttend> ReadAttend(string lid)
        {
            DBservices dbs = new DBservices();
            List<ListofAttend> lc = dbs.ReadAttend("PersonStringName", "StudentsLab", lid);
            return lc;
        }

    }
}