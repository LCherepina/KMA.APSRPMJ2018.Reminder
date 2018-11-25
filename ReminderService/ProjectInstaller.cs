
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Architecture_Reminder.ReminderService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private void InitializeComponent()
        {
            this._serviceProcessInstaller = new ServiceProcessInstaller();
            this._serviceInstaller = new ServiceInstaller();
            // 
            // _serviceProcessInstaller
            // 
            this._serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            this._serviceProcessInstaller.Password = null;
            this._serviceProcessInstaller.Username = null;

            this._serviceInstaller.DisplayName = "Reminder Simulator Service1";
            this._serviceInstaller.ServiceName = "ReminderSimulatorService1";

            this._serviceProcessInstaller.AfterInstall += new InstallEventHandler(this._serviceProcessInstaller_AfterInstall);
            // 
            // _serviceInstaller
            // 
            this._serviceInstaller.StartType = ServiceStartMode.Automatic;
            this._serviceInstaller.AfterInstall += new InstallEventHandler(this._serviceInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new Installer[] {
                this._serviceProcessInstaller,
                this._serviceInstaller});

        }

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private ServiceProcessInstaller _serviceProcessInstaller;
        private ServiceInstaller _serviceInstaller;

        private void _serviceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void _serviceProcessInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
