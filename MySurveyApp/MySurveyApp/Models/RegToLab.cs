using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class RegToLab
    {
        public string Username { get; set; }
        public string LabId { get; set; }
        
        public float Labweight { get; set; }
  


        public RegToLab(string un, string li, float _labweight)
        {

            LabId = un;
            Username = un;
            Labweight = _labweight;
          
        }
        public int Regtolab(string un, string Lid, float wei)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.Regtolab(un,  Lid,  wei);
            return numAffected;
        }
        public RegToLab()
        {

        }
      
        public int deletereglab(string un, string Lid)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.deletereglab(un, Lid);
            return numAffected;
        }

        public List<RegToLab> ifuserreg(string un, string Lid)
        {
            DBservices dbs = new DBservices();
            List<RegToLab> lc = dbs.ifuserreg("PersonStringName", "StudentsLab", un,Lid);
            return lc;
        }
        public List<RegToLab> ReadRegStud(string Lid)
        {
            DBservices dbs = new DBservices();
            List<RegToLab> lc = dbs.ReadRegStud("PersonStringName", "StudentsLab",Lid);
            return lc;
        }

    }
}