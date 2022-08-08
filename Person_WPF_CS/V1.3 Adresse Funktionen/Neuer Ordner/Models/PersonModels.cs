using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Person_WPF_CS.Models
{
    public class PersonModels
    {
        public PersonModels()
        {
            conn = new SQLiteConnection(connStr);
            conn.Open();
        }
        string connStr = @"Data source=C:\temp\mydb.db";
        SQLiteConnection conn;

        public bool IsRegistered(Person p)
            {

                bool res = false;

                string sql = "INSERT INTO person (UserID,UserPW,Vorname,Nachname,EMail,TelNr) VALUES ('"
                    + p.ID + "','" + p.PW + "','" + p.Vorname + "','" + p.Nachname + "','" + p.EMail + "','"+p.TelNr+"');";
                var cmd = new SQLiteCommand(sql, conn);
                Int32 IsExecutedGood;

                //var conn = new SQLiteConnection(connStr);
                //conn.Open();
                try
                {
                    IsExecutedGood = cmd.ExecuteNonQuery(); cmd.Dispose();
                    if (IsExecutedGood != 0) { res = true; }
                    else { res = false; }
                }
                catch (InvalidCastException e)
                { Console.WriteLine("{0}has been occured", e); }
                catch (InvalidOperationException e)
                { Console.WriteLine("{0}has been occured", e); }
                catch (SQLiteException e)
                { Console.WriteLine("{0}has been occured", e); }

                return res;
                //catch(ObjectDisposedException e)
                //{ Console.WriteLine("{0}has been occured", e); }

                //Rueckgabewert kann 0 oder andere Zahl,was ist abhaengigkeit darueber, 
                //dass die DBMS welche fehlermeldung nachrichtet haben, sein.


                //binden DB

                //wenn neue ID und PW erfolgreich registriert, der zuruewert ist 'true'
                //wenn es etwas problem gibt auf dem Registrierenprozess, der zuruewert ist 'false' 

            }

        public Person getPersonFromDB(string UserID)
        {
            Person Pers = new Person();
            string sql = string.Format("SELECT * FROM Person where UserID = '{0}';",UserID);

            SQLiteCommand mySQLiteCmd = new SQLiteCommand(sql, conn);

            SQLiteDataReader sqliteReader = mySQLiteCmd.ExecuteReader();

            while (sqliteReader.Read())
            {
                Pers.ID = sqliteReader["UserID"] as string;
                Pers.PW = sqliteReader["UserPW"] as string;
                Pers.Vorname = sqliteReader["Vorname"] as string;
                Pers.Nachname = sqliteReader["Nachname"] as string;
                Pers.EMail = sqliteReader["EMail"] as string;
                Pers.TelNr = sqliteReader["TelNr"] as string;
                Pers.Lieferadresse = sqliteReader["Lieferadresse"] as string;
            }
            mySQLiteCmd.Dispose();

            return Pers;
        }

        public void EinstellenLieferadresse(Adresse Adr, string UserID)
        {
            string sql = string.Format("UPDATE Person SET Lieferadresse = '{0}' Where UserID = '{1}';", Adr.AdresseID, UserID);
            SQLiteCommand mySQLiteCommand = new SQLiteCommand(sql, conn);
            try
            {
                mySQLiteCommand.ExecuteNonQuery(); mySQLiteCommand.Dispose();
            }
            catch (InvalidCastException e)
            { Console.WriteLine("{0}has been occured", e); }
            catch (InvalidOperationException e)
            { Console.WriteLine("{0}has been occured", e); }
            catch (SQLiteException e)
            { Console.WriteLine("{0}has been occured", e); }
        }
    }
    
}
