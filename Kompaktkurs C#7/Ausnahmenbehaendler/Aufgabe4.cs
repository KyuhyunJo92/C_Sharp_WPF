using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AusnahmenHandling
{
    class Aufgabe4
    {
        //konstruktor
        public Aufgabe4()
        {
            _keller = new int[10];
            TopOfStack = 0;
        }
        private int[] _keller;
        //finden wo gerade Dach ist.
        private int _topOfStack;
        private int TopOfStack { get { return _topOfStack; } set { _topOfStack = value; } }

        /*for (int i = 0; i < 10; i++)
                {
                    if (_keller[i] == -1)
                    {
                        _topOfStack = i;
                        break;
                    }
                }
                return _topOfStack;*/
        public void Push(int wert)
        {
            //Alle Elemente des Arrays '_keller' sind initialisiert als 100 wurde.
            //wo der Element 0 ist, noch nicht nummer geraden. 0 bedeutet "leer"   

            if (TopOfStack >= 10)
            {
                throw new KellerOverFlowException();
            }
            else
            {
                _keller[TopOfStack] = wert;
                TopOfStack=TopOfStack+1;//i++, i+=1;
            }
        }

        public void Pop()
        {
            if (TopOfStack <= 0)
            {
                throw new KellerUnterFlowException();
            }
            else
            {
                //Console.WriteLine( _keller[TopOfStack-1]);
                TopOfStack=TopOfStack-1;
            }
        }

        public override string ToString()
        {
            string res = "";
            for(int i=0; i<TopOfStack; i++)
            {
                res += _keller[i];
                res += ";";
            }
            res += "\n";
            return res;
        }

        //public void MustThrowOverFlowException()
        //{
        //    for (int i = 0; i < 15; i++)
        //    {
        //        try
        //        {
        //            Push(i);
        //        }
        //        catch (KellerOverFlowException e)
        //        {
        //            Console.WriteLine("Error Message : KellerOverFlowException");
        //            break;
        //        }

        //    }
        //    foreach(int arg in _keller) { Console.WriteLine("{0}", arg); }
        //}

        //public void MustThrowUntererFlowException()
        //{
        //    for (int i = 0; i < 15; i++)
        //    {
        //        try
        //        {
        //            Pop();
        //        }
        //        catch (KellerUnterFlowException e)
        //        {
        //            Console.WriteLine(string.Format("Error Message : KellerUnterFlowException"));
        //            break;
        //        }

        //    }
        //}

    }
    class A4Test
    {
        static public void NachschlagenKellerStack()
        {
            Aufgabe4 A4 = new Aufgabe4();
            A4.Push(324);
            A4.Push(1245432);
            A4.Push(6213);
            A4.Pop();
            A4.Pop();


            Console.Write(A4.ToString());
        }

        static public void MustThrowOverFlowException()
        {
            Aufgabe4 A4 = new Aufgabe4();
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    A4.Push(i);
                }
                catch (KellerOverFlowException e)
                {
                    Console.WriteLine("Error Message : KellerOverFlowException");
                    break;
                }

            }

        }

        static public void MustThrowUntererFlowException()
        {
            Aufgabe4 A4 = new Aufgabe4();
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    A4.Pop();
                }
                catch (KellerUnterFlowException e)
                {
                    Console.WriteLine(string.Format("Error Message : KellerUnterFlowException"));
                    break;
                }

            }
        }
    }
    //ExceptionsVonAufgabe4
    class KellerException : Exception
    {
    }
    class KellerOverFlowException : KellerException
    {
    }
    class KellerUnterFlowException : KellerException
    {
    }
}
//private int TopOfStack
//{
//    get
//    {
//        int i = 0;
//        while (true)
//        {

//            if (_keller[i] == -1)
//            {
//                _topOfStack = i;
//                break;
//            }
//            i++;
//        }
//        return _topOfStack;

//    }
//}
//if (wert < 0) throw new InvalidArgumentException()
//{
//    argument = wert,
//    Range = "Ein negative Ganzzahl kann nicht wert eingegeben werden. bitte geben Sie einen positive Ganzzahl ein."
//};
//for (int i = 0; i < 10; i++)
//{
//    _keller[i] = -1;
//}