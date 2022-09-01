using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ein_undAusgebe
{
    class A8Telefonbuch
    {
        Hashtable Telefonbuch;

        string path = @"c:\temp\19_5_Aufgabe8_Telefonbuch.txt";//=>pfad zu einer Datei.
        //C:\temp das ist ein Pfad zu einem Verzeichnis.

        public A8Telefonbuch()
        {}
        
        public string ReadFile()
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            fs.Seek(0, SeekOrigin.Begin);//from Beginning point.

            string _dummyString = "";
            //StringBuilder sb = new StringBuilder(_dummyString);

            int ch = fs.ReadByte();
            while (ch >= 0)
            {
                _dummyString += (char)ch;
                //_dummyString.Insert(_dummyString.Length, Convert.ToString((char)ch));
                //sb.Append(ch);
                ch = fs.ReadByte();
            }
            //_dummyString = sb.ToString();
            
            return _dummyString;
        }

        public void WriteTelbuch(string ReadData)
        {
            Telefonbuch = new Hashtable();

            string[] ArrSentence = ReadData.Split('|');

            for(int i = 0; i < ArrSentence.Length; i++)
            {
                string[] ArrPair = ArrSentence[i].Split(',');
                Telefonbuch.Add(ArrPair[0], ArrPair[1]);
            }
        }
        
        public object ReadPhoneNr(string Name)
        {
            return Telefonbuch[Name];
        }
        
        //static void Main()
        //{
        //    A8Telefonbuch A8 = new A8Telefonbuch();
        //    A8.WriteTelbuch(A8.ReadFile());

        //    Console.WriteLine(A8.ReadPhoneNr("Han"));
        //}
                
        //static void Main()
        //{
        //    A8Telefonbuch.HashtableTest();
        //}
        //static public void HashtableTest()
        //{
        //    Hashtable population = new Hashtable();
        //    population["Austria"] = 7583000;
        //    population["Germany"] = 77573000;
        //    population["France"] = 56138000;

        //    foreach (DictionaryEntry x in population) Console.WriteLine("{0} = {1}", x.Key, x.Value);
        //}

    }
}
