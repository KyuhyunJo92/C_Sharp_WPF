using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_WPF_CS.Models
{
    public class Adresse
    {
        public int AdresseID { get; set; }
        public string HausNr { get; set; }
        public string Strasse { get; set; }
        public string PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }
        public string AdrTyp { get; set; }
        //public string UserId { get; set; }


        public Adresse(){}
        public Adresse(string HausNr, string Strasse, string PLZ, string Stadt, string Land)
        {
            this.HausNr=HausNr;
            this.Strasse= Strasse;
            this.PLZ=PLZ;
            this.Stadt=Stadt;
            this.Land=Land;
        }
        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0} {1}\n",Strasse, HausNr);
        }
    }
}
