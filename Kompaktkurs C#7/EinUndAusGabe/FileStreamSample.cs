using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ein_undAusgebe
{
    class FileStreamSample
    {
        public static void Copy(string pathFromFile, string pathToFile /*, int pos*/)
        {
            try
            {
                //if (!File.Exists(pathFromFile)) { File.Create(pathFromFile); }
                FileStream fsFrom = new FileStream(pathFromFile, FileMode.Create);
                fsFrom.Seek(0, SeekOrigin.Begin);

                byte[] Arr = new byte[15];
                //Einfuellen random Byte(0 ~ 255) Element to 'bArr'.
                //new Random().NextBytes(Arr);
                Arr[0] = (byte)73;
                Arr[1] = (byte)32;
                Arr[2] = (byte)65;
                Arr[3] = (byte)77;
                Arr[4] = (byte)32;
                Arr[5] = (byte)73;
                Arr[6] = (byte)82;
                Arr[7] = (byte)79;
                Arr[8] = (byte)78;
                Arr[9] = (byte)32;
                Arr[10] = (byte)77;
                Arr[11] = (byte)65;
                Arr[12] = (byte)78;
                Arr[13] = (byte)32;
                Arr[14] = (byte)32;
                //Write a byte of Data
                for (int i = 0; i < Arr.Length; i++)
                {
                    fsFrom.WriteByte(Arr[i]);
                }
                fsFrom.Seek(0, SeekOrigin.Begin);

                FileStream fsTo = new FileStream(pathToFile, FileMode.Create);
                fsTo.Seek(0, SeekOrigin.Begin);

                int aByte = fsFrom.ReadByte();
                //cursor initialize.
                

                //if 'aByte'is -1, fsFrom is empty.
                while (aByte >= 0)
                {
                    fsTo.WriteByte((byte)aByte);
                    aByte = fsFrom.ReadByte();
                }

                fsTo.Seek(0, SeekOrigin.Begin);
                //test
                //for(int i=0; i < fsTo.Length; i++)
                //{
                //    Console.Write("{0} ;", fsTo.ReadByte());
                //}
                fsTo.Flush();

                fsFrom.Close();
                fsTo.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("-- file {0} not found", e.FileName);
            }
        }
        public static void Read(string path)
        {
            FileStream fsRead = new FileStream(path, FileMode.Open);
            fsRead.Seek(0, SeekOrigin.Begin);

            int aByte = fsRead.ReadByte();

            while (aByte >= 0)
            {
                Console.Write("{0}", (char)aByte);

                aByte = fsRead.ReadByte();
            }

            fsRead.Close();
        }

        //static void Main()
        //{
        //    string pathFromFile = @"c:/temp/pathFromFile.dat";
        //    string pathToFile = @"c:/temp/pathToFile.dat";

        //    FileStreamSample.Copy(pathFromFile, pathToFile);
        //    FileStreamSample.Read(pathToFile);
        //}
    }
}
/*public static void Copy(string fromFile, string toFile, int pos)
        {
            try
            {
                FileStream sin = new FileStream(fromFile, FileMode.Open);
                FileStream sout = new FileStream(toFile, FileMode.Create);
                sin.Seek(pos, SeekOrigin.Begin);
                int ch = sin.ReadByte();
                while ( ch>=0)
                {
                    sout.WriteByte((byte)ch);
                    ch = sin.ReadByte();
                }
                sin.Close();
                sout.Close();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("-- file {0} not found", e.FileName);
            }   
        }*/

/*static void Main(string[] args)
{
    FileStreamSample.Copy(args[0], args[1], Convert.ToInt32(args[2]));
}*/
