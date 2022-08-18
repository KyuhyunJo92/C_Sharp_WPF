using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var directory = Directory.GetCurrentDirectory();
            var directory = @"C:\temp";
            var Watcher = new Watcher();
            Watcher.Init(directory);

            Console.WriteLine("Zeichnis:" + directory);
            Console.WriteLine("'q' to quit");
            while (Console.Read() != 'q') ;
        }
    }
}

public class Watcher
{
    private readonly FileSystemWatcher m_watcher = new FileSystemWatcher();
    public void Init(string path)
    {
        m_watcher.Path = path;

        m_watcher.NotifyFilter = NotifyFilters.Size|NotifyFilters.DirectoryName|NotifyFilters.FileName;
        
        m_watcher.Filter = "*.*";

        m_watcher.Changed += OnChanged;
        m_watcher.Created += OnChanged;
        m_watcher.Deleted += OnChanged;
        m_watcher.Renamed += OnRenamed;

        m_watcher.EnableRaisingEvents = true;
        m_watcher.IncludeSubdirectories = true;
    }

    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        Console.WriteLine($"File: {e.FullPath} {e.ChangeType} ");
    }
    private static void OnRenamed(object source, RenamedEventArgs e)
    {
        Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
}

/* 
| NotifyFilters.LastAccess
| NotifyFilters.LastWrite
| NotifyFilters.FileName
| NotifyFilters.DirectoryName
*/
