using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class Status
    {
        public string Username { get; set; }
      
        public float Surveyammount { get; set; }
        public float Labsammount { get; set; }
      






        public Status(string _us ,float _sammount ,float _lammount )
        {

            Username = _us;
           
            Surveyammount = _sammount;
            Labsammount = _lammount;
          
         
        
       
        
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
        public List<Status> ReadstatusforApp(string un)
        {
            DBservices dbs = new DBservices();
            List<Status> lc = dbs.ReadstatusforApp("PersonStringName", "studentstatus", un);
            return lc;
        }
      
       

        public float Readspecstud(string un)
        {
            DBservices dbs = new DBservices();
            float lc = dbs.Readspecstud("PersonStringName", "studentstatus", un);
            return lc;
        }


        public int Editstatusfromapp(string un, float wei)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.Editstatusfromapp(un,wei);
            return numAffected;
        }

        public int inserthourfromapp(string un, float wei)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.inserthourfromapp(un, wei);
            return numAffected;
        }






    }
}