using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Person_WPF_CS.Models
{
    class RegisterModel
    {
        public RegisterModel()
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
        public bool IsRegistered(Person p)
        {
            bool res = false;

            string sql = "INSERT INTO person (User_ID,User_PW,Vorname,Nachname,E_Mail,Tel_Nr,Haus_Nr,PLZ) VALUES ('"
                +p.ID+"','"+p.PW+"','"+p.Vorname+"','"+p.Nachname+"','"+p.EMail+"','"+p.TelNr+"','"+p.HausNr+"','"+p.PLZ+"');";

            //var conn = new SQLiteConnection(connStr);
            //conn.Open();
            var cmd = new SQLiteCommand(sql, conn);

            //Rueckgabewert kann 0 oder andere Zahl,was ist abhaengigkeit darueber, 
            //dass die DBMS welche fehlermeldung nachrichtet haben, sein.
            Int32 IsExecutedGood = cmd.ExecuteNonQuery();
            cmd.Dispose();

            if(IsExecutedGood != 0){res = true;}
            
            return res;
            //binden DB

            //wenn neue ID und PW erfolgreich registriert, der zuruewert ist 'true'
            //wenn es etwas problem gibt auf dem Registrierenprozess, der zuruewert ist 'false' 

        }

    }
}
