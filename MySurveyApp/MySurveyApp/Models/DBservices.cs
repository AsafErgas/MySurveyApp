using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using MySurveyApp.Models;
using System.Text;
using System.Globalization;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

	public DBservices()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

   
  
        //XXXXXXXXXXX-LOGIN FUN- start-XXXXXXXXXXXXXXXX
          public List<Lecturer> Login(string conString, string tableName, string UserName, string Password)
    {

        SqlConnection con = null;
        List<Lecturer> lc = new List<Lecturer>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " where username = '" + UserName + "' and password = '" + Password + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Lecturer s = new Lecturer();
                s.Id = (string)dr["id"];
                s.Name = (string)dr["firstname"];
                s.FamilyName = (string)dr["lastname"];
                s.Email = (string)dr["email"];
                s.UserName = (string)dr["username"];
                s.Password = (string)dr["password"];


                lc.Add(s);
            }

            return lc;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    //XXXXXXXXXXX-LOGIN FUN- ending - XXXXXXXXXXXXXXXX

    //    XXXXXXXXX-READ ALL SURVEY - START-XXXXXXX
   
    public List<Survey> ReadAllSurvey(string conString, string tableName, string lecId)
    {

        SqlConnection con = null;
        List<Survey> lc = new List<Survey>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName+ " WHERE lecturerId= "+ lecId;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Survey s = new Survey();
                s.SurveyId = (string)dr["surveyId"];
                s.Topic = (string)dr["topic"];
                s.Uploaddate = (DateTime)dr["uploaddate"];
                s.Enddate = (DateTime)dr["enddate"];
                s.Minperson = Convert.ToInt32(dr["minperson"]);
                s.Maxperson = Convert.ToInt32(dr["maxperson"]);
                s.Details = (string)dr["details"];
                s.Auther = (string)dr["auther"];
                s.Surveyweight =Convert.ToSingle(dr["surveyweight"]); 
                s.Lecturerid = (string)dr["lecturerId"];
                s.Link = (string)dr["link"];
                s.Isopensurvey = Convert.ToInt32(dr["opensurvey"]);
                s.Currentnumofpers= Convert.ToInt32(dr["currentnumofpers"]);

                lc.Add(s);
            }

            return lc;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    //XXXXXXXXXX-READ ALL SURVEY-END-XXXXXXXXXXXXXX

    //XXXXXXXXX-READ SURVEY FUN - START-XXXXXXXXXXXXX

    public List<Survey> ReadSurvey(string conString, string tableName, string lecId, int Isopen)
    {

        SqlConnection con = null;
        List<Survey> lc = new List<Survey>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " WHERE lecturerId= " + lecId + " and opensurvey = "+Isopen;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Survey s = new Survey();
                s.SurveyId = (string)dr["surveyId"];
                s.Topic = (string)dr["topic"];
                s.Uploaddate = (DateTime)dr["uploaddate"];
                s.Enddate= (DateTime)dr["enddate"];
                s.Minperson = Convert.ToInt32(dr["minperson"]);
                s.Maxperson = Convert.ToInt32(dr["maxperson"]);
                s.Details = (string)dr["details"];
                s.Auther = (string)dr["auther"];
                s.Surveyweight = Convert.ToSingle(dr["surveyweight"]);
                s.Lecturerid = (string)dr["lecturerId"];
                s.Link = (string)dr["link"];
                s.Isopensurvey = Convert.ToInt32(dr["opensurvey"]);
                s.Currentnumofpers = Convert.ToInt32(dr["currentnumofpers"]);




                lc.Add(s);
            }

            return lc;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    //XXXXXXXXXX-READ SURVEY END-XXXXXXXXXXXX

    //XXXXXXXXXXXX-INSERT SURVEY APP - START-XXXXXXXXXX
            public int insertsurvey(Survey s)
    {

        SqlConnection con;
        SqlCommand cmd;
     

        try
        {
            con = connect("PersonStringName"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        // helper method to build the insert string

        String cStr = BuildInsertCommand(s);
        cmd = CreateCommand(cStr, con);



        // create the command

        try
        {

            //int pizzaIdfromDB = (int)cmd.ExecuteScalar();

            cmd = CreateCommand(cStr, con);

            int numEffected = cmd.ExecuteNonQuery();

            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }

        }

    }





    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Survey s)
    {

        String command;
        string year = s.Uploaddate.Year.ToString();
        string month= s.Uploaddate.Month.ToString();
        string day= s.Uploaddate.Day.ToString();
        string FF = month + '/' + day + '/' + year;

        string year2 = s.Enddate.Year.ToString();
        string month2 = s.Enddate.Month.ToString();
        string day2 = s.Enddate.Day.ToString();
        string FF2 = month2 + '/' + day2 + '/' + year2;
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}','{4}','{5}','{6}',{7},{8},{9},'{10}',{11},{12})", s.SurveyId, s.Topic, s.Details, s.Auther, s.Lecturerid, FF.ToString(), FF2.ToString(), s.Minperson.ToString(), s.Maxperson.ToString(),  s.Surveyweight.ToString(),  s.Link, s.Isopensurvey.ToString(), s.Currentnumofpers.ToString());
        String prefix = "INSERT INTO Survey " + "(surveyId, topic,details, auther,lecturerId, uploaddate, enddate, minperson, maxperson, surveyweight, link, opensurvey, currentnumofpers) ";
        command = prefix + sb.ToString();
        return command;

    }
    //XXXXXXXXXXXX-INSERT SURVEY APP - END-XXXXXXXXXX

    //XXXXXXXXXXX-EDITSURVEY- START-XXXXXXXXXXXXXXX
    public int Editsurvey(Survey s,string sid)
    {

        SqlConnection con;
        SqlCommand cmd;


        try
        {
            con = connect("PersonStringName"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        // helper method to build the insert string

        String cStr = BuildInsertCommand2(s,sid);
        cmd = CreateCommand(cStr, con);



        // create the command

        try
        {

            //int pizzaIdfromDB = (int)cmd.ExecuteScalar();

            cmd = CreateCommand(cStr, con);

            int numEffected = cmd.ExecuteNonQuery();

            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }

        }

    }





    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand2(Survey s,string sid)
    {
        string year = s.Uploaddate.Year.ToString();
        string month = s.Uploaddate.Month.ToString();
        string day = s.Uploaddate.Day.ToString();
        string FF = month + '/' + day + '/' + year;

        string year2 = s.Enddate.Year.ToString();
        string month2 = s.Enddate.Month.ToString();
        string day2 = s.Enddate.Day.ToString();
        string FF2 = month2 + '/' + day2 + '/' + year2;

        string command = "UPDATE Survey SET surveyId='" + s.SurveyId + "' , topic='" + s.Topic + "' , uploaddate= '" + FF + "' ,enddate='" + FF2 + "' , minperson='" + s.Minperson + "' , maxperson='" + s.Maxperson + "' , details='" + s.Details + "' , auther='" + s.Auther + "' , surveyweight='" + s.Surveyweight + "' , lecturerId='" + s.Lecturerid + "' , link='" + s.Link + "' , opensurvey='" + s.Isopensurvey + "' WHERE surveyId=" + sid;
        return command;
    }




    //XXXXXXXXXXX-EDITSURVEY- END-XXXXXXXXXXXXXXX


    //XXXXXXXXXXX-READ STATUS- START
    public List<Status> Readstatus(string conString, string tableName)
    {

        SqlConnection con = null;
        List<Status> lc = new List<Status>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName ;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Status s = new Status();
                s.Username = (string)dr["username"];
                s.SurveyId = (string)dr["surveyId"];
                s.Surveyammount = Convert.ToInt32(dr["surveyammount"]);
                s.Labsammount = Convert.ToInt32(dr["labsammount"]);
                s.LabId= (string)dr["labId"];
                s.Sum= Convert.ToInt32(dr["sum"]);


                lc.Add(s);
            }

            return lc;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    //XXXXXXXX-READ-STATUS-END-XXXXXXXXXXXXX
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXX-DELETE-SURVEY-START-XXXXXXXXXXXXXXXXXXXX
    public int deletesurvey(Survey s, string sid)
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd2;


        try
        {
            con = connect("PersonStringName"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        // helper method to build the insert string
        
        String cStr = BuildInsertCommand3(s, sid);
        String cStr2 = BuildInsertCommand4(s, sid);
       
        cmd = CreateCommand(cStr, con);
        cmd2 = CreateCommand(cStr2, con);


        // create the command

        try
        {

            //int pizzaIdfromDB = (int)cmd.ExecuteScalar();

            cmd = CreateCommand(cStr, con);
            cmd2 = CreateCommand(cStr2, con);
            int numEffected = cmd.ExecuteNonQuery();
            int numEffected2 = cmd2.ExecuteNonQuery();
            return numEffected + numEffected2 ;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }

        }

    }





    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand3(Survey s, string sid)
    {


        string command = "DELETE from studentstatus where surveyId='" + sid +"'";
        return command;
    }
    private String BuildInsertCommand4(Survey s, string sid)
    {


        string command = "DELETE from Survey where surveyId='" + sid + "'";
        return command;
    }
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX-DELETE-SURVEY-END-XXXXXXXXXXXXXXXX
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX-GET-NUM-OF STUDENT-START-XXXXXXXXXXXXXXXXXX
    public int Numofstudent(string conString, string tableName)
    {

        SqlConnection con = null;
        int sum = 0;
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

           
            String selectSTR = "SELECT COUNT(username) as sum1 FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            
            while (dr.Read())
            {   // Read till the end of the data into a row
                 sum = Convert.ToInt32(dr["sum1"]);
              
             


             
            }

            return sum;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX-GET-NUM-OF STUDENT-END-XXXXXXXXXXXXXXXXXX

    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX-GET-Insert STUDENT-START-XXXXXXXXXXXXXXXXXX

    public int insertstudent(Student s)
    {

        SqlConnection con;
        SqlCommand cmd;


        try
        {
            con = connect("PersonStringName"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        // helper method to build the insert string

        String cStr = BuildInsertCommand4(s);
        cmd = CreateCommand(cStr, con);



        // create the command

        try
        {

            //int pizzaIdfromDB = (int)cmd.ExecuteScalar();

            cmd = CreateCommand(cStr, con);

            int numEffected = cmd.ExecuteNonQuery();

            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }

        }

    }





    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand4(Student s)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}')", s.Username, s.Password );
        String prefix = "INSERT INTO Student " + "(username, password) ";
        command = prefix + sb.ToString();
        return command;
    }









    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX-GET-Insert STUDENT-END-XXXXXXXXXXXXXXXXXX


    //    XXXXXXXXX-READ Filter LABS - START-XXXXXXX
    public List<Lab> ReadLabs(string conString, string tableName, string lecId)
    {

        SqlConnection con = null;
        List<Lab> lc = new List<Lab>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName + " WHERE lecturerId= " + lecId;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Lab L = new Lab();
                L.LabId = (string)dr["labId"];
                L.Labtopic = (string)dr["labtopic"];
                L.Labdate = (DateTime)dr["labdate"];
                L.Minperson = Convert.ToInt32(dr["minpers"]);
                L.Maxperson = Convert.ToInt32(dr["maxpers"]);
                L.Labdetails = (string)dr["labdetails"];
                L.Director = (string)dr["Director"];
                L.Labweight = Convert.ToSingle(dr["labweight"]);
                L.Lablocation = (string)dr["lablocation"];


                lc.Add(L);
            }

            return lc;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    //    XXXXXXXXX-READ Filter Labs - END-XXXXXXX

    //    XXXXXXXXX-READ ALL Labs - START-XXXXXXX
    public List<Lab> ReadAllLabs(string conString, string tableName)
    {

        SqlConnection con = null;
        List<Lab> lc = new List<Lab>();
        try
        {
            con = connect(conString); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Lab L = new Lab();
                L.LabId = (string)dr["labId"];
                L.Labtopic = (string)dr["labtopic"];
                L.Labdate = (DateTime)dr["labdate"];
                L.Minperson = Convert.ToInt32(dr["minpers"]);
                L.Maxperson = Convert.ToInt32(dr["maxpers"]);
                L.Labdetails = (string)dr["labdetails"];
                L.Director = (string)dr["Director"];
                L.Labweight = Convert.ToSingle(dr["labweight"]);
                L.Lablocation = (string)dr["lablocation"];


                lc.Add(L);
            }

            return lc;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    //    XXXXXXXXX-READ ALL Labs - END-XXXXXXX

    //XXXXXXXXX-INSERT LAB- START-XXXXXXXXX

    public int insertlab(Lab l)
    {

        SqlConnection con;
        SqlCommand cmd;


        try
        {
            con = connect("PersonStringName"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        // helper method to build the insert string

        String cStr = BuildInsertCommand(l);
        cmd = CreateCommand(cStr, con);



        // create the command

        try
        {

            //int pizzaIdfromDB = (int)cmd.ExecuteScalar();

            cmd = CreateCommand(cStr, con);

            int numEffected = cmd.ExecuteNonQuery();

            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }

        }

    }





    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Lab l)
    {
        String command;

        string year = l.Labdate.Year.ToString();
        string month = l.Labdate.Month.ToString();
        string day = l.Labdate.Day.ToString();
        string FF = month + '/' + day + '/' + year;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}' ,{2}, {3},'{4}','{5}',{6},'{7}','{8}')", l.LabId, l.Labtopic, l.Minperson.ToString(), l.Maxperson.ToString(), l.Labdetails, l.Director, l.Labweight.ToString(), l.Lablocation, FF.ToString());
        String prefix = "INSERT INTO Labs " + "(labId, labtopic, minpers,maxpers, labdetails, Director, labweight, lablocation,labdate) ";
        command = prefix + sb.ToString();
        return command;

    }
    //XXXXXXXXXXXX-INSERT SURVEY APP - END-XXXXXXXXXX











































    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)

    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }


}
