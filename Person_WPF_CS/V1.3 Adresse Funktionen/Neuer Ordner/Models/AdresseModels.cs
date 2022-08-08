using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Person_WPF_CS.Models
{
    public class AdresseModels
    {
        public AdresseModels()
        {
            conn = new SQLiteConnection(connStr);
            conn.Open();
        }
        string connStr = @"Data source=C:\temp\mydb.db";
        SQLiteConnection conn;
        //public Adresse getAdrVonDB(string ID, string AdrType)
        //{
        //    Adresse Adr = new Adresse();
        //    string sql = "SELECT * FROM Adresse where USERID='" + ID + "' AND AdrTyp='" + AdrType + "';";
        //    //SQLiteConnection sqConnection = new SQLiteConnection(sqConnectionString);
        //    SQLiteCommand mySQLiteCommand = new SQLiteCommand(sql, conn);

        //    try
        //    {
        //        //mySQLiteCommand.Connection.Open();
        //        SQLiteDataReader sqliteReader = mySQLiteCommand.ExecuteReader();

        //        while (sqliteReader.Read())
        //        {
        //            Adr.AdresseID = sqliteReader["AdresseID"] as string;
        //            Adr.HausNr = sqliteReader["HausNr"]as string;
        //            Adr.Strasse = sqliteReader["Strasse"] as string;
        //            Adr.PLZ = sqliteReader["PLZ"] as string;
        //            Adr.Stadt = sqliteReader["Stadt"] as string;
        //            Adr.Land = sqliteReader["Land"] as string;
        //        }
        //    }
        //    catch (InvalidOperationException e)
        //    { Console.WriteLine("{0}has been occured", e); }
        //    finally
        //    {
        //        //sqliteReader.Close();
        //        //conn.Close();
        //        mySQLiteCommand.Dispose();
        //    }
        //    return Adr;
        //}
        public List<Adresse> getAdrListVonDB(string CurrentAccount)
        {
            List<Adresse> listAdr =new List<Adresse>(); 
            string sql = "SELECT * FROM Adresse where UserID='" + CurrentAccount + "';";
            //SQLiteConnection sqConnection = new SQLiteConnection(sqConnectionString);
            SQLiteCommand mySQLiteCommand = new SQLiteCommand(sql, conn);
            try
            {
                //mySQLiteCommand.Connection.Open();
                SQLiteDataReader sqliteReader = mySQLiteCommand.ExecuteReader();
                while (sqliteReader.Read())
                {
                    Adresse Adr = new Adresse();
                    Adr.AdresseID = int.Parse(sqliteReader["AdresseID"].ToString());
                    Adr.AdrTyp = sqliteReader["AdrTyp"] as string;
                    Adr.HausNr = sqliteReader["HausNr"] as string;
                    Adr.Strasse = sqliteReader["Strasse"] as string;
                    Adr.PLZ = sqliteReader["PLZ"] as string;
                    Adr.Stadt = sqliteReader["Stadt"] as string;
                    Adr.Land = sqliteReader["Land"] as string;
                    
                    listAdr.Add(Adr);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("{0}has been occured", e);
            }
            finally
            {
                //sqliteReader.Close();
                //conn.Close();
                mySQLiteCommand.Dispose();
            }
            return listAdr;
        }
        public void AdrHinzufuegen(string CurrentAccount, Adresse NeueAdr)
        {
            string sql = string.Format("INSERT INTO Adresse(HausNr,Strasse,PLZ,Stadt,Land,AdrTyp,UserID) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                NeueAdr.HausNr,NeueAdr.Strasse, NeueAdr.PLZ, NeueAdr.Stadt, NeueAdr.Land, NeueAdr.AdrTyp,CurrentAccount);
            //SQLiteConnection sqConnection = new SQLiteConnection(sqConnectionString);
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
        public void AdresseBearbeiten(Adresse SelectedAdr)
        {
            string sql = string.Format("UPDATE Adresse SET HausNr = '{0}'"+
                ",Strasse = '{1}', PLZ='{2}', Stadt='{3}', Land='{4}', AdrTyp='{5}' where AdresseID = {6};",
                SelectedAdr.HausNr,SelectedAdr.Strasse,SelectedAdr.PLZ,SelectedAdr.Stadt,SelectedAdr.Land,SelectedAdr.AdrTyp,SelectedAdr.AdresseID );
            
            SQLiteCommand mySQLiteCommand = new SQLiteCommand(sql, conn);
            try
            {
                mySQLiteCommand.ExecuteNonQuery();
            }
            catch (InvalidCastException e)
            { Console.WriteLine("{0}has been occured", e); }
            catch (InvalidOperationException e)
            { Console.WriteLine("{0}has been occured", e); }
            catch (SQLiteException e)
            { Console.WriteLine("{0}has been occured", e); }
            finally
            {
                mySQLiteCommand.Dispose();
            }
        }
        public void AdresseLoeschen(Adresse SelectedAdr, string CurrentAccount)
        {
            string sql = string.Format("Delete FROM Adresse where AdrTyp = '{0}' AND UserID = '{1}';",
                SelectedAdr.AdrTyp, CurrentAccount);

            SQLiteCommand mySQLiteCommand = new SQLiteCommand(sql, conn);
            try
            {
                mySQLiteCommand.ExecuteNonQuery();
            }
            catch (InvalidCastException e)
            { Console.WriteLine("{0}has been occured", e); }
            catch (InvalidOperationException e)
            { Console.WriteLine("{0}has been occured", e); }
            catch (SQLiteException e)
            { Console.WriteLine("{0}has been occured", e); }
            finally
            {
                mySQLiteCommand.Dispose();
            }
        }
    }
}
