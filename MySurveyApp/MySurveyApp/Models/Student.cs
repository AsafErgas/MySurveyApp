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
        public string Token { get; set; }
        public bool Ise { get; set; }
        public bool Isav { get; set; }






        public Student(string _user, string _pass, string t, bool i,bool isav)
        {

            Username = _user;
            Password = _pass;
            Token = t;
            Ise = i;
            Isav = isav;



        }

        public Student()
        {

        }
        public bool checking(List<Student> l, string U, string P)
        {
            bool exs = false;
            if ((l[0].Username == U) && (l[0].Password == P))
            {
                exs = true;

            }
            return exs;



        }
        public List<Student> Login(string Username, string Password)
        {
            DBservices dbs = new DBservices();
            List<Student> lc = dbs.Login("PersonStringName", "Student", Username, Password);
            lc[0].Ise = checking(lc, Username, Password);
            return lc;

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
        public List<Student> getstudforpush(string un)
        {
            DBservices dbs = new DBservices();
            List<Student> lc = dbs.getstudforpush("PersonStringName", "Student", un);
            return lc;
        }
        public int EditPass(string sid)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.EditPass(this, sid);
            return numAffected;
        }

        public int deletestudent(string un)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.deletestudent(this, un);
            return numAffected;
        }
        public int Edittoken(string t, string un)
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.Edittoken(t, un);
            return numAffected;
        }


    }
}