using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriterEx
{
    delegate void LogWriter(string message);
    class Program
    {
        static void Main(string[] args)
        {
            LogSchreiber logSchreiber = new LogSchreiber();
            //event Abonnenten
            //LogWriter Log= new LogWriter(NachrichtAusgeber);
            //AnonymMethoden
            //LogWriter Log = new LogWriter(delegate (string message) { Console.WriteLine("{0}", message); });
            //LambdaAusdruck
            LogWriter Log = new LogWriter((string message)=> { Console.WriteLine("{0}", message); });
            Log += logSchreiber.DateiSchreiber;

            Log.Invoke("Hello,World!");
            Log.Invoke("kyuhyun");
            Log.Invoke("Hello,World!");

            logSchreiber.Flush();
        }
        private static void NachrichtAusgeber(string message)
        {
            //uebergebene Nachricht auf den Bildschirm ausgegen.
            Console.WriteLine("{0}", message);
        }
    }


    public class LogSchreiber
    {
        private FileStream fs;
        string path = @"c:\temp\abc.txt";
        StreamWriter sw;

        public LogSchreiber()
        {
            fs = new FileStream(path, FileMode.Create);
            sw = new StreamWriter(fs);
        }
        
        public void DateiSchreiber(string message)
        {
            sw.WriteLine(message);

        }
        public void Flush()
        {
            sw.Flush();
            //fs.Flush();
            
        }
    }
}



//namespace LogWriterEx
//{
//    delegate void LogWriter(string message);
//    class Program
//    {
//        static void Main(string[] args)
//        {

//        }
//    }

//    public class myClass
//    {

//        LogWriter Log;
//        FileStream fs;
//        string path = @"c:\temp";

//        public void installiert()
//        {
//            Log += NachrichtAusgeber;
//            Log += DateiSchreiber;
//            //fs = new FileStream(path, FileMode.Open);
//        }
//        private void NachrichtAusgeber(string message)
//        {
//            //uebergebene Nachricht auf den Bildschirm ausgegen.
//            Console.WriteLine("{0}", message);
//        }
//        private void DateiSchreiber(string message)
//        {
//            fs.Write()
//        }
//        public void Flush()
//        {
//            fs.Flush();
//        }
//    }
//}
