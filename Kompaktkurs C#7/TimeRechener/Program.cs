using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TimeRechner
{
    class Program
    {
        static void Main(string[] args)
        {
            

            

            // ---------------------------------------------------------
            // Test: Properties:
            {
                Time t = new Time(3, 45, 22);
                Debug.Assert(t.Second == 22);
                Debug.Assert(t.Minute == 45);
                Debug.Assert(t.Hour == 3);
            }

            // Test: Properties mit Umwandlung:
            {
                Time t = new Time(3661);
                Debug.Assert(t.Second == 1);
                Debug.Assert(t.Minute == 1);
                Debug.Assert(t.Hour == 1);
            }

            // Test: Properties mit Überlauf:
            {
                Time t = new Time(100000);
                Debug.Assert(t.Second == 40);
                Debug.Assert(t.Minute == 46);
                Debug.Assert(t.Hour == 3);
            }

            // Test: ToString()-Format:
            {
                Time t = new Time(10, 15, 20);
                Debug.Assert(t.ToString() == "10:15:20");
            }

            // Test: ToString()-Format mit führenden Nullen:
            {
                Time t = new Time(1, 2, 3);
                Debug.Assert(t.ToString() == "01:02:03");
            }

            // Test: Überlauf 1
            {
                Time t = new Time(24, 0, 0);
                Debug.Assert(t.ToString() == "00:00:00");
            }

            // Test: Überlauf 2
            {
                Time t = new Time(25, 65, 94);
                Debug.Assert(t.ToString() == "02:06:34");
            }

            // Test: Addititon
            {
                Time t1 = new Time(8, 30, 0);
                Time t2 = new Time(0, 50, 0);
                Debug.Assert((t1 + t2).ToString() == "09:20:00");
            }

            // Test: Addititon mit Überlauf
            {
                Time t1 = new Time(23, 59, 59);
                Time t2 = new Time(1, 2, 4);
                Debug.Assert((t1 + t2).ToString() == "01:02:03");
            }
            Time uz1 = new Time(100);
            Time uz2 = new Time(100);

            Time uz_addieren = uz1 + uz2;
            Console.WriteLine(string.Format("{0} + {1} = {2}",uz1.ToString(), uz2.ToString(), uz_addieren.ToString()));

            Time uz3 = new Time(93599);
            Console.WriteLine(uz3.ToString2());

            Time uz4 = new Time(25, 61, 61);
            Console.WriteLine(uz4.ToString2());
        }
    }
    public struct Time
    {
        private int _gesamtSekunden;
        private int GesamtSekunden
        {
            get { return _gesamtSekunden; }
            set { _gesamtSekunden = value; }
        }
        public double Tage
        {
            get { return Math.Truncate((double)GesamtSekunden / 86400); }
        }
        public double Hour
        {
            get { return Math.Truncate((double)(GesamtSekunden % 86400) / 3600); }
        }
        public double Minute
        {
            get { return Math.Truncate((double)((GesamtSekunden % 86400) % 3600) / 60); } //Umrechnen Minuten von Sekunden
        }
        public double Second
        {
            get { return (double)((GesamtSekunden % 86400) % 3600) % 60; }
        }
        /*
         * Mit Tage berechnen.
        //public double Tage
        //{
        //    get { return Math.Truncate((double)GesamtSekunden / 86400); }
        //}
        //public double Hour
        //{
        //    get { return Math.Truncate((double)(GesamtSekunden % 86400) / 3600); }
        //}
        //public double Minute
        //{
        //    get { return Math.Truncate((double)((GesamtSekunden % 86400) % 3600) / 60); } //Umrechnen Minuten von Sekunden
        //}
        //public double Second
        //{
        //    get { return (double)((GesamtSekunden % 86400) % 3600) % 60; }
        //}
        */


            //constructors
        public Time(int sekunden)
        {
            _gesamtSekunden = sekunden;
        }
        public Time(int stunden, int minuten, int sekunden)
        {
            _gesamtSekunden = (stunden * 3600) + (minuten * 60) + (sekunden);
        }
        public override string ToString()
        {
            return string.Format("{0:00}:{1:00}:{2:00}", Hour, Minute, Second);
        }

        //public override string ToString()
        //{
        //    var HourStr = new StringBuilder();
        //    if(Hour<10)
        //    {
        //        HourStr.Append("0");
        //        HourStr.Append(Convert.ToString(Hour));
        //    }
        //    else { HourStr.Append(Convert.ToString(Hour)); }
        //    var MinStr = new StringBuilder();
        //    if (Minute < 10)
        //    {
        //        MinStr.Append("0");
        //        MinStr.Append(Convert.ToString(Minute));
        //    }
        //    else { MinStr.Append(Convert.ToString(Minute)); }
        //    var SecStr = new StringBuilder();
        //    if (Second < 10)
        //    {
        //        SecStr.Append("0");
        //        SecStr.Append(Convert.ToString(Second));
        //    }
        //    else { SecStr.Append(Convert.ToString(Second)); }
        //    return string.Format("{0}:{1}:{2}",HourStr,MinStr,SecStr);
        //}
        //
        public  string ToString2()
        {
            return string.Format("{4} Sekunden ist {3} Tage, {0}:{1}:{2}.",Hour,Minute,Second,Tage,GesamtSekunden);
        }
        public static Time operator +(Time U1, Time U2)
        {
            int res = U1.GesamtSekunden + U2.GesamtSekunden;
            Time U_result = new Time(res);
            return U_result;
        }


    }
}
