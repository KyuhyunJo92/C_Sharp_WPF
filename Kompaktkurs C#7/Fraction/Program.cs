using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Fraction f = new Fraction(2, 3);
        //    f.Add(new Fraction(4, 5));
        //    Console.WriteLine("z={0},n={1}", f.z, f.n);
        //    f.Mulitply(new Fraction(4, 5));
        //    //Console.WriteLine( f.ToString());
        //    Console.WriteLine("z={0},n={1}", f.z, f.n);
        //    int[] i;
        //}

        static int CompareLength(Fraction f1, Fraction f2)
        {
            return f1.fractionValue.CompareTo(f2.fractionValue);
        }

        
        static void Main(string[] args)
        {
            //    Fraction f1 = new Fraction(2, 3);
            //    Fraction f2 = new Fraction(3, 4);

            //IComparer revComparer = new ReverseComparer();

            Fraction[] fArr = new Fraction[5];
            fArr[0] = new Fraction(5, 6);
            fArr[1] = new Fraction(3, 4);
            fArr[2] = new Fraction(1, 2);
            fArr[3] = new Fraction(4, 5);
            fArr[4] = new Fraction(2, 3);

            for(int i = 0; i<fArr.Length; i++)
            {
                Console.WriteLine(fArr[i].ToString());
            }
            Console.WriteLine("===================================");

            //Array.Sort(fArr, revComparer);
            Comparison<Fraction> comparison = new Comparison<Fraction>(CompareLength);
            Array.Sort(fArr, comparison);
            for (int i = 0; i < fArr.Length; i++)
            {
                Console.WriteLine(fArr[i].ToString());
            }
            
        }

        public class ReverseComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(y, x);
            }
        }

        class Fraction /*: IComparable*/
        {
            //Zhaler, Nenner 
            public int z, n;
            public double fractionValue;

            //construct
            public Fraction(int z, int n)
            {
                this.z = z;
                this.n = n;
                this.fractionValue = ((double)z) / n;
            }

            public void Add(Fraction f) { z = z * f.n + n * f.z; n = n * f.n; }

           

            public void Mulitply(Fraction f) { z = z * f.z; n = n * f.n; }

            //public int CompareTo(object obj)
            //{
            //    Fraction anotherF = (Fraction)obj;
            //    if (fractionValue > anotherF.fractionValue) { return 1; }
            //    else if (fractionValue == anotherF.fractionValue) { return 0; }
            //    else { return -1; }
            //}


            //public int CompareTo(object obj)
            //{
            //    Fraction anotherF = (Fraction)obj;
            //    return anotherF.fractionValue.CompareTo(anotherF);
            //}

            public override string ToString()
            {
                return string.Format("{0}/{1}", this.z, this.n);
            }
        }
    }
}
//main
//Item apple = new Item();
//apple.idNumber = 15;
//Item banana = new Item();
//banana.idNumber = 4;
//Item cow = new Item();
//cow.idNumber = 15;
//Item diamond = new Item();
//diamond.idNumber = 18;
//Console.WriteLine(apple.CompareTo(banana)); 
//Console.WriteLine(apple.CompareTo(cow)); 
//Console.WriteLine(apple.CompareTo(diamond));
