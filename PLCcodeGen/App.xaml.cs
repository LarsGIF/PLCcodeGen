using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PLCcodeGen.Properties;

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
        } 
    }
}
