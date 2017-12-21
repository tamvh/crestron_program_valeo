using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace wsclient_pro
{
    public class Database
    {
        private SqlConnection myConnection;
        public string databasename;
        public void connect(string userid, string password, string server, string database)
        {
            databasename = database;
            myConnection = new SqlConnection("user id=" + userid + ";" + "password=" + password + ";" + "server=" + server + ";" + "database=" + database + ";");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error while connecting to the database:" + e.ToString());
            }
        }

    }
}