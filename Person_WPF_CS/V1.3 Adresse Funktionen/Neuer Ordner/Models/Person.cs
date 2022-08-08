using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_WPF_CS.Models
{
    public class Person
    {
        public string ID { get; set; }
        public string PW { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string EMail { get; set; }
        public string TelNr { get; set; }
        public string Lieferadresse { get; set; }
        //List<Adresse>...

        //default Konstruktor
        public Person() { }

        //overloaded Konstruktor
        //public Person(string ID,string PW, string Vorname, string Nachname, string EMail, string TelNr)
        //{
        //    this.ID=ID;
        //    this.PW=PW;
        //    this.Vorname= Vorname;
        //    this.Nachname= Nachname;
        //    this.EMail= EMail;
        //    this.TelNr=TelNr;
        //}
    }
}
