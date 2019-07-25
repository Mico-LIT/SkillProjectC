using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();

            base.Installers.Add(new ServiceProcessInstaller()
            {
                Account = ServiceAccount.LocalSystem
            });

            base.Installers.Add(new ServiceInstaller() {
                ServiceName="[==TEST SERVICES==]",
                Description = "My First service",
                StartType = ServiceStartMode.Automatic
            });
        }
    }
}
