using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Person_WPF_CS.Models
{
    class LoginModel
    {
        public LoginModel()
        {
            conn = new SQLiteConnection(connStr);
            conn.Open();
        }
        //~LoginModel()
        //{
        //    conn.Close();
        //}
        string connStr = @"Data source=C:\temp\mydb.db";
        SQLiteConnection conn;
        public bool AreIDandPWCorrect(string ID, string PW)
        {

            bool res = false;
            
            //string connStr = @"Data source=C:\temp\mydb.db";
            //string stm = "SELECT SQLITE_VERSION();";
            string sql = "SELECT Count(*) from person where User_ID = '" + ID + "' AND User_PW = '"+ PW+"';";

            //var conn = new SQLiteConnection(connStr);
            //conn.Open();
            var cmd = new SQLiteCommand(sql,conn);


            //Int32 existingCount = Convert.ToInt32(cmd.ExecuteScalar());
            Int32 existingCount = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            //conn.Close();

            if (existingCount != 0) { res = true; }

            return res;
            //if (existingCount == 0)
            //cmd.CommandText = @"SELECT User_PW from person where User_ID = '"+ID+"';";
            //cmd.ExecuteNonQuery();
            //Binden DB
            //select the person from tbl_person whose ID is eingegebende ID,
            //vergleichen beide ID und PW.
            //wenn Beide sind gleich -> res=true
            //else -> false
            //string version = cmd.ExecuteScalar().ToString();
            //Console.WriteLine($"### this SQLite version : (version)");
 
        }
    }
}
