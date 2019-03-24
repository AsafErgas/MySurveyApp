using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Yearofstudy { get; set; }
      
 




        public Student(string _id , string _user,string _pass ,string _year)
        {

            Id = _id;
            Username = _user;
            Password = _pass;
            Yearofstudy = _year;
        
       
        
        }

        public Student()
        {

        }


        //public List<Student> Readstudent(string studentid)
        //{
        //    DBservices dbs = new DBservices();
        //    List<Student> lc = dbs.Readstudent("PersonStringName", "Student", studentid);
        //    return lc;
        //}

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