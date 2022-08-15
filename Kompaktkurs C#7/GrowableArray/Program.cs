using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowableArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            {
                GrowableArray<int> TgA = new GrowableArray<int>(5);
                Debug.Assert(TgA[0] == 0);
            }
            //test

            GrowableArray<int> gA1 = new GrowableArray<int>(5);
            gA1.ShowAllElem();
            Console.WriteLine(gA1.ToString());

            GrowableArray<int> gA2 = gA1;

            gA1[5] = 5;
            gA1[6] = 6;
            gA1.ShowAllElem();
            Console.WriteLine(gA1.ToString());
            Console.WriteLine("gA1 HashCode : {0}", gA1.GetHashCode());
            
            Console.WriteLine("gA2 HashCode : {0}", gA2.GetHashCode());

            Console.WriteLine("gA1 = gA2 ? : {0}", gA1.Equals(gA2));

        }
    }

    class GrowableArray<T> : IEnumerable<T>
    {
        public GrowableArray(int arrLength)
        {
            gArr = new T[arrLength];
        }
        public T[] gArr;

        public T this[int index]
        {
            get { return gArr[index]; }
            set
            {
                if (index >= gArr.Length)
                {
                    T[] tempArr = new T[gArr.Length];
                    tempArr = gArr;
                    gArr = new T[index + 1];
                    for (int i = 0; i != tempArr.Length; i++)
                    {
                        gArr[i] = tempArr[i];
                    }
                }
                gArr[index] = value;
            }
        }

        public void ShowAllElem()
        {
            int index = 0;
            foreach(T elem in gArr)
            {
                Console.WriteLine("arr[{0}] : {1}", index, elem);
                index++;
            }
        }

        public override string ToString()
        {
            return base.ToString();
            //return string.Format("Length of Array : {0}", gArr.Length);
        }
        public void Print()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Length of Array : {0}", gArr.Length);
            for (int idx = 0; idx != gArr.Length; idx++)
            {
                Console.WriteLine("{0}te Elemente ist {1}", idx, gArr[idx]);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
/*
//Enumerable.Repeat<int>(i, arrLength-1).ToArray<int>
            //initialize gArr[i] = i
            //for (int i = 0; i < arrLength; i++)
            //{
            //    gArr[i] = i;
            //}*/

/*
 * //static void Main(string[] args)
        //{
        //    int[] arr = new int[7] { 11, 'a', 13, 14, 15, 16, 17 };
        //    Console.WriteLine("## foreach ");
        //    int index = 0;
        //    foreach (char elem in arr)
        //    {
        //        Console.WriteLine("arr[" + index + "] : " + elem); ++index;
        //    }
        //    Console.WriteLine("current i : " + index);
        //    Console.WriteLine();
        //    Console.WriteLine("## for ");
        //    for (int i = 0; i < 7; ++i)
        //    {
        //        Console.WriteLine("arr[" + i + "] : " + arr[i]);
        //    }
        //}*/

/*public class Students
    {
        public static int TotalMarks(params int[] list)
        {
            int total = 0;
            for (int i = 0; i < list.Length; i++)
                total += list[i];
            return total;
        }

        public static string AllSubjects(params string[] subjects)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            for (int i = 0; i < subjects.Length; i++)
            {
                builder.Append(subjects[i]);
                builder.Append(" ");
            }
            return builder.ToString();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // Total for 3rd grade. Pass 3 comma separate values as params  
            Console.WriteLine("Params with 3 parameters");
            int total3 = Students.TotalMarks(8, 9, 8);
            // Print result  
            Console.WriteLine(total3);
            // Create an array of strings   
            string[] subs = { "English", "Reading", "Writing" };
            // Pass array of strings as a params and print result  
            Console.WriteLine(Students.AllSubjects(subs));

            // Total for 8th grade          
            Console.WriteLine("Params with 4 parameters");
            int[] marks = { 24, 22, 25, 21 };
            int total4 = Students.TotalMarks(marks);
            string str4 = Students.AllSubjects("Math", "English", "Art", "Social Science");
            Console.WriteLine(total4);
            Console.WriteLine(str4.ToString());

            // Total for 10th grade  
            Console.WriteLine("Params with 5 parameters");
            int total5 = Students.TotalMarks(92, 90, 95, 91, 98);
            string str5 = Students.AllSubjects(new string[] { "Math", "English", "Art", "Social Science", "Gym" });
            Console.WriteLine(total5);
            Console.WriteLine(str5.ToString());

            Console.ReadKey();
        }

    }*/