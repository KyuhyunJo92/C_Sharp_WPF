using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusnahmenHandling
{
   
    class Aufgabe5
    {
        //public static int maxIntValue = 2147483647;
        static public void Test()
        {
            try
            {
                Console.WriteLine(Power(0, 3));
                //Console.WriteLine(Power(2, -1));
            }
            catch (PowerException e) { Console.WriteLine(e.Message); }
            catch (OverflowException e) { Console.WriteLine(e.Message); }

            try
            {
                Console.WriteLine(Power(0, 3));
                //Console.WriteLine(Power(2, -1));
            }

            catch (PowerException e) { Console.WriteLine(e.Message); }
            catch (OverflowException e) { Console.WriteLine(e.Message); }
            //catch (WrongExponentException e) { Console.WriteLine(e.Message); }
            //catch (WrongBaseException e) { Console.WriteLine(e.Message); }
            //catch (OverflowException e) { Console.WriteLine(e.Message); }

            try
            {
                //Console.WriteLine(Power(0, 3));
                Console.WriteLine(Power(2, -1));
            }

            catch (PowerException e) { Console.WriteLine(e.Message); }
            catch (OverflowException e) { Console.WriteLine(e.Message); }
            //catch (WrongExponentException e) { Console.WriteLine(e.Message); }
            //catch (WrongBaseException e) { Console.WriteLine(e.Message); }
            //catch (OverflowException e) { Console.WriteLine(e.Message); }

            try
            {
                //Console.WriteLine(Power(0, 3));
                Console.WriteLine(Power(2, 3));
            }
            catch (PowerException e) { Console.WriteLine(e.Message); }
            catch (OverflowException e) { Console.WriteLine(e.Message); }
            //catch (WrongExponentException e) { Console.WriteLine(e.Message); }
            //catch (WrongBaseException e) { Console.WriteLine(e.Message); }
            //catch (OverflowException e) { Console.WriteLine(e.Message); }

        }
        static int Power(int x, int y)
        {
            int res = 0;
            if (x == 0) throw new WrongBaseException();
            else if (y <= 0) throw new WrongExponentException();
            else
            {
                res = 1;
                //checked
                {
                    for (int i = 0; i < y; i++)
                    {
                        res *= x;
                    }
                }
            }
             return res;
        }
    }
    class WrongBaseException : PowerException
    {
       public WrongBaseException() : base("Base muss nicht gleich 0 sein.") { }
    }
    public class WrongExponentException : PowerException
    {
        public WrongExponentException() : base("Exponent nuss grosser als 0 sein.") { }
    }
    public class PowerException : Exception
    {
        public PowerException(string msg) : base(msg) { }
        public PowerException() : base("Algemeine PowerExceoption") { }
    }

}
