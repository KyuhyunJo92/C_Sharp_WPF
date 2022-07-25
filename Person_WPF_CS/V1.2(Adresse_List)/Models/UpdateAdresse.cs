using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Person_WPF_CS.Models
{
    class UpdateAdresse : Person
    {
        //private Adresse _Adr;
        public UpdateAdresse()
        {
            //_Adr = EinAdrWasAktualisierenMochten;
            conn = new SQLiteConnection(connStr);
            conn.Open();
        }

        string connStr = @"Data source=C:\temp\mydb.db";
        SQLiteConnection conn;
        
        public void Execute(Adresse Adr,string ID, string AdrType)
        {
            string sql = "SELECT * FROM Adresse where P_ID="+ID+"' AND AdrType='"+AdrType+"';" ;
            //SQLiteConnection sqConnection = new SQLiteConnection(sqConnectionString);
            SQLiteCommand sqCommand = new SQLiteCommand(sql, conn);
            sqCommand.Connection.Open();
            SQLiteDataReader sqliteReader = sqCommand.ExecuteReader();
            try
            {
                while (sqliteReader.Read())
                {
                    Adr.HausNr = sqliteReader.GetString(0);
                    Adr.Strasse = sqliteReader.GetString(1);
                    Adr.PLZ = sqliteReader.GetString(2);
                    Adr.Stadt= sqliteReader.GetString(3);
                    Adr.Land = sqliteReader.GetString(4);
                }
            }
            finally
            {
                sqliteReader.Close();
                conn.Close();
            }
            
        }
    }
}
