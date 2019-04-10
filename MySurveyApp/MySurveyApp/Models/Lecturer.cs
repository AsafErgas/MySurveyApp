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
        public bool Ise { get; set; }


        public Lecturer(string _id, string _name, string _familyName, string _email, string _username, string _password,bool ise)
        {

            Id = _id;
            Name = _name;
            FamilyName = _familyName;
            Email = _email;
            UserName = _username;
            Password = _password;
            Ise = ise;
        }

        public Lecturer()
        {

        }
     
        public List<Lecturer> Loginserver(string UserName, string Password)
        {
            DBservices dbs = new DBservices();
            List<Lecturer> lc = dbs.Loginserver("PersonStringName", "Lecturer", UserName, Password);
     
            return lc;

        }



    }
}