using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PLCcodeGen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ObservableCollection<Project> myProjects = new ObservableCollection<Project>();

        #region Properties Getters and Setters
        public ObservableCollection<Project> MyProjects
        {
            get { return this.myProjects; }
            set { this.myProjects = value; }
        }
        #endregion

        void AppStartup(object sender, StartupEventArgs args)
        {
            Project proj = new Project();
            proj.LineName = "Underbody Line";
            proj.CtrlArea = new ControlArea("BUB");
            proj.CtrlArea.BaseProj = "AZS_16F2T24X";
            myProjects.Add(proj);
        }
    }
}
