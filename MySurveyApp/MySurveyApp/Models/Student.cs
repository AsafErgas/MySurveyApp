using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class Student
    {
     
        public string Username { get; set; }
        public string Password { get; set; }
      
 




        public Student( string _user,string _pass )
        {

            Username = _user;
            Password = _pass;
         
        
       
        
        }

        public Student()
        {

        }


        public int Numofstudent()
        {
            DBservices dbs = new DBservices();
            int lc = dbs.Numofstudent("PersonStringName", "Student");
            return lc;
        }

        public int insertstudent()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insertstudent(this);
            return numAffected;
        }
        public List<Student> ReadStudent()
        {
            DBservices dbs = new DBservices();
            List<Student> lc = dbs.ReadStudent("PersonStringName", "Student");
            return lc;
        }
        public int EditPass(string sid)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.EditPass(this, sid);
            return numAffected;
        }




    }
}