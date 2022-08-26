using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusnahmenHandling
{
    class Aufgabe6
    {
        //Das aktuelle TextWruter-Objekt
        private TextWriter _stringWriter;
        private TextWriter _alteTW;
        //private TextWriter _newSW;
        private string _path;
        public string path { get { return  _path; } set { _path = value; } }

        public Aufgabe6()
        {
            _alteTW = Console.Out;
            //path = @"c:\temp\abc.txt";
            //path = "";
            _stringWriter = new StringWriter();
            //_stringWriter = new StringWriter();
            //_newSW = new MyStringWriter();
        }
        
        public void Print(string path)
        {
            //uninitialiserte path
            if (path == null) throw new ArgumentNullException();

            //directory is too long
            else if (path.Length > 260) throw new PathTooLongException();

            //File is not exist.
            else if (!File.Exists(path)) throw new ArgumentException();

            else { Console.WriteLine(File.GetCreationTime(path)); Console.WriteLine("File Read Successful"); }
            //Console.WriteLine(File.ReadAllText(path));
            
        }
    }

    class A6Test
    {
        static public void WithTryCatchBlock()
        {
            Aufgabe6 A6 = new Aufgabe6();
            
            try { A6.Print(A6.path); }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }
            finally {  }

            A6.path = @"C:\temp\NonExist.txt";

            try { A6.Print(A6.path); }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }

            A6.path = @"C:\temp\aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbc\cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc\aa.txt"; 

            try{ A6.Print(A6.path); }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }

            A6.path = @"c:\temp\abc.txt";

            try { A6.Print(A6.path); }
            catch (Exception e) { Console.WriteLine("{0}", e.Message); }
        }

        static public void WithoutTryCatchBlock()
        {
            Aufgabe6 A6 = new Aufgabe6();

            A6.path = @"C:\temp\NonExist.txt";
            A6.Print(A6.path);

            A6.path = @"C:\temp\aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbc\cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc\aa.txt";
            A6.Print(A6.path);

            A6.path = @"c:\temp\abc.txt";
            A6.Print(A6.path);

        }
    }
}
