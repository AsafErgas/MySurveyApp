using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySurveyApp.Models
{
    public class Lecturer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }



        public Lecturer(string _id , string _name, string _familyName, string _email,string _username,string _password)
        {

            Id = _id;
            Name = _name;
            FamilyName = _familyName;
            Email = _email;
            UserName = _username;
            Password = _password;
        }

        public Lecturer()
        {

        }

        public List<Lecturer> Login(string UserName,string Password)
        {
            DBservices dbs = new DBservices();
            List<Lecturer> lc = dbs.Login("PersonStringName", "Lecturer", UserName, Password);
            return lc;

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

        //public List<Student> Filter()
        //{
        //    DBservices dbs = new DBservices();
        //    List<Student> lc = dbs.Filter("PersonStringName", "Student");
        //    return lc;
        //}
        //public int Update(Person p , int id)
        //{
        //    DBservices dbs = new DBservices();
        //    int numAffected = dbs.Update(p,id);
        //    return numAffected;
        //}


    }
}