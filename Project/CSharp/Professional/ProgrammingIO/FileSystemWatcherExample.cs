using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO
{
    class FileSystemWatcherExample
    {
        public FileSystemWatcherExample()
        {
            var watcher = new FileSystemWatcher(@".");

            watcher.Created += new FileSystemEventHandler(WatcherChanged);
            watcher.Deleted += WatcherChanged;

            // Начать мониторинг
            watcher.EnableRaisingEvents = true;

            var change = watcher.WaitForChanged(WatcherChangeTypes.All);
            Console.WriteLine(change.ChangeType);

            Console.ReadLine();
        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Directory changed({e.ChangeType}): {e.FullPath}");
        }
    }
}
