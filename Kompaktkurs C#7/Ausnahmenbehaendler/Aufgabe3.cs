using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusnahmenHandling
{
    class Aufgabe3
    {
        FileStream fs;
        string path = @"c:\temp\TryAnweisung.txt";
        public Aufgabe3()
        {
            fs = null;
            try { fs = new FileStream(path, FileMode.Open); }
            catch (FileNotFoundException e) { Console.WriteLine("file {0} not found", e.FileName); }
            catch (IOException e) { Console.WriteLine("some IO exception ocurred : {0}"); }
            finally { if (fs != null) fs.Close(); }
        }
    }
}
