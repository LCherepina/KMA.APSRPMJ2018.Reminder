
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
            this._serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this._serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // _serviceProcessInstaller
            // 
            this._serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this._serviceProcessInstaller.Password = null;
            this._serviceProcessInstaller.Username = null;
            this._serviceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this._serviceProcessInstaller_AfterInstall);
            // 
            // _serviceInstaller
            // 
            this._serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this._serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this._serviceInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
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
