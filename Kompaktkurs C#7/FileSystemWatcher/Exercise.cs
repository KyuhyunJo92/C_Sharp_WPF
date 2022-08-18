using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ex = new Exercise();
            var path = @"C:\temp";
            ex.Init(path);

            Console.WriteLine("Directory:" + path);
            Console.WriteLine("'q' to quit");
            while (Console.Read() != 'q') ;
        }
    }
}
    public class Exercise
    {
        private readonly FileSystemWatcher Monitor = new FileSystemWatcher();

        public void Init(string path)
        {
            
            Monitor.Path = path;

            Monitor.NotifyFilter = NotifyFilters.DirectoryName;

            Monitor.Changed += OnChanged;
            Monitor.Created += OnChanged;
            Monitor.Deleted += OnChanged;
            Monitor.Disposed +=OnDisposed;
            Monitor.Renamed += OnRenamed;

            Monitor.Filter = "*.*";

            Monitor.EnableRaisingEvents = true;
            Monitor.IncludeSubdirectories = true;

        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(string.Format("{0} has been renamed to {1}", e.OldName, e.Name));
        }

        private static void OnDisposed(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("{0}", e.ToString()));
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(string.Format("File : {0}, {1}", e.FullPath, e.ChangeType));
        }
}
//|NotifyFilters.Size