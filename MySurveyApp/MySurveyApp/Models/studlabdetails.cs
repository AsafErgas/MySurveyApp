using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class studlabdetails


    {
        public string Username { get; set; }
      
        public string LabId { get; set; }
        public float Labweight { get; set; }
      






        public studlabdetails(string _us ,string _lid ,float _lw )
        {

            Username = _us;

            LabId = _lid;
            Labweight = _lw;
          
         
        
       
        
        }

        public studlabdetails()
        {

        }


        public List<studlabdetails> Readdetails2(string usern)
        {
            DBservices dbs = new DBservices();
            List<studlabdetails> lc = dbs.Readdetails2("PersonStringName", "studentlabsstatus", usern);
            return lc;
        }

      




    }
}