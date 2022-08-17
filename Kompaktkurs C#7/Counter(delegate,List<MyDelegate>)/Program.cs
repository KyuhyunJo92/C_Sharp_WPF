using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter
{
    public delegate bool Bedingung(int ZaehlerWert);
    public delegate void MyAction(int ZaehlerWert);


    class Program
    {
        static void Main(string[] args)
        {
            Counter C1 = new Counter(0);

            //Console.WriteLine(C1.GetWert());

            //Bedingung b = new Bedingung(CompareHundert);
            C1.SetCondition(CompareHundert);

            //MyAction add = new MyAction(Add);
            C1.SetAction(PrintToScreen);
            C1.SetAction(PrintToScreen2);

            C1.Add(50);
            C1.Add(51);
        }

        public static bool CompareHundert(int z)
        {
            bool res;
            if (z < 100) { res = false; }
            else { res = true; }
            return res;
        }
        public static void PrintToScreen(int z)
        {
            Console.WriteLine(string.Format("Zaehlerwert : {0}", z));
        }
        public static void PrintToScreen2(int z)
        {
            Console.WriteLine(string.Format("ZweiteAction : {0}", z));
        }
    }



    class Counter
    {
        private int _wert = 0;
        public Counter(int x) { _wert = x; _act = new List<MyAction>(); }

        private Bedingung _bed;
        private List<MyAction> _act;//mehrere Aktionen 

        public void SetCondition(Bedingung bed) { _bed = bed; }
        public void SetAction(MyAction act)
        {
            _act.Add(act);
        }
        //public int GetWert() { return _wert; }
        //public Bedingung GetCondition() { return _bed; }
        //public MyAction GetAction() { return _act; }

        //MyActions
        public void Add(int x)
        {
            _wert += x;

            //wenn die bedingung erfuellt wird, ist die Rueckgabe 'true'.
            if (_bed.Invoke(_wert))
            {
                //Ausloesen alle Aktion von 'List<MyAction>'. 
                foreach (MyAction elem in _act) { elem.Invoke(_wert); }
            }
        }
        public void Clear() { _wert = 0; }
    }
}

//for (int i = 0; i < 100; i++)
//{
//    C1.GetAction().Invoke(10);
//    if (C1.GetCondition().Invoke(C1.GetWert()).Equals(true)) { C1.Clear(); }
//    Console.WriteLine(C1.GetWert()); }