using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter
{
    delegate bool Condition(int ZaehlerWert);
    delegate void MyAction(int ZaehlerWert);

    class UserBenutzen
    {
        static void Main(string[] args)
        {
            Exercise E = new Exercise();

            E.SetCondition(IsPrimeNumber);
            E.SetAction(MonitorNumber);

            for(int i=0; i<1000000; i++)
            {
                E.Add(1);
            }
            
        }
        //user definierte inplementierung der Delegation
        //Condition
        static bool IsOddNumber(int ZaehlerWert)
        {
            bool res;
            if (ZaehlerWert % 2 == 1)
            {
                res = true;
            }
            else res = false;

            return res;
        }
        static bool IsEvenNumber(int ZaehlerWert)
        {
            bool res;
            if (ZaehlerWert % 2 == 0)
            {
                res = true;
            }
            else res = false;

            return res;
        }
        static bool IsPrimeNumber(int ZaehlerWert)
        {
            bool res = true;
            for(int i = 2; i*i <= ZaehlerWert; i++)
            {
                if(ZaehlerWert%i == 0) { res = false; }
            }
            return res;
        }
        static void MonitorNumber(int ZaehlerWert)
        {
            Console.WriteLine(string.Format("Zahl : {0}", ZaehlerWert));
        }
    }




    class Exercise
    {
        //constructor
        public Exercise(int zaehlerWert)
        {
            _zaehlerWert = zaehlerWert;
            myActions = new List<MyAction>();
        }
        public Exercise()
        {
            _zaehlerWert = 0;
            myActions = new List<MyAction>();
        }

        //member variable
        private int _zaehlerWert;

        event Condition myConditions;
        List<MyAction> myActions;
        //setter
        public void SetCondition(Condition C)
        {
            myConditions += C;
        }
        public void SetAction(MyAction A)
        {
            myActions.Add(A);
        }


        //member method
        public void Add(int AddedNumber)
        {
            _zaehlerWert += AddedNumber;
            if (myConditions.Invoke(_zaehlerWert))
            {
                foreach (MyAction elem in myActions) { elem.Invoke(_zaehlerWert); }
            }
        }


    }
}
