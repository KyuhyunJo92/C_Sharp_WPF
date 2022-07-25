using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Person_WPF_CS.Models
{
    class AdresseFensterNeuLadenModel
    {
        string connStr = @"Data source=C:\temp\mydb.db";
        SQLiteConnection conn;


        public AdresseFensterNeuLadenModel(string ID)
        {
            this._ID = ID;
            conn = new SQLiteConnection(connStr);
            conn.Open();
        }

        private string _ID;

        public Adresse execute(string AdresseNummer)
        {
            Adresse adr = new Adresse();
            string sql="select * from Adresse;";


            return adr;
        }
    }
}
