using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        FileInfo file;
        StreamWriter writer;
        FileSystemWatcher watcher;

        public Service1()
        {
            InitializeComponent();
            this.CanStop = true; // службу можно остановить

            file = new FileInfo(@"C:\Test\Log.txt");
            writer = file.CreateText();

            watcher = new FileSystemWatcher(@"C:\Test\");
            watcher.Created += WatherChanged;
            watcher.Deleted += WatherChanged;
            watcher.Renamed += WatherChanged;
            watcher.Changed += WatherChanged;

        }

        private void WatherChanged(object sender, FileSystemEventArgs e)
        {
            writer.WriteLine($"Directory changed({e.ChangeType}) : {e.FullPath}");
            writer.Flush();
        }

        protected override void OnStart(string[] args)
        {
            watcher.EnableRaisingEvents = true;
        }

        protected override void OnStop()
        {
            watcher.EnableRaisingEvents = false;
            writer.Close();
            writer.Dispose();
        }
    }
}
