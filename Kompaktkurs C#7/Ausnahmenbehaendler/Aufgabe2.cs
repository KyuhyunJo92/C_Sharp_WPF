using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusnahmenHandling
{
    class Aufgabe2
    {
        static void Test()
        {
            //Beispiel von OverflowException.
            //int Zahl > mathPow(2,32), error
            string s1 = "4294967297";
            int Zahl1;
            try { Zahl1 = Convert.ToInt32(s1); }
            catch (FormatException) { }
            catch (OverflowException) { Console.WriteLine(string.Format("{0}>{1}", s1, Math.Pow(2, 32))); }
            finally { }

            //Beispiel von FormatException.
            string s2 = "6a7890";
            int Zahl2;
            try { Zahl2 = Convert.ToInt32(s2); }
            catch (FormatException) { Console.WriteLine(string.Format("Ungueltige Format : {0}", s2)); }
            catch (OverflowException) { }
            finally { }

            Console.WriteLine("Obwohl es Fehler aufgetreten ist, laeuft das Program noch.");
        }

    }
}
