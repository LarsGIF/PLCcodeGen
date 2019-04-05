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
            Project prj;

            if (Settings.Default.LoadPreviousProject)
            {
                // Load last opened project
                if (myProjects.Count == 0)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Project));
                    try
                    {
                        using (FileStream fileStream = new FileStream(Settings.Default.PreviousProjectPath, FileMode.Open))
                        {
                            prj = (Project)serializer.Deserialize(fileStream);
                        }
                        ((App)Application.Current).MyProjects.Add(prj);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open previous file!", "File Open Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.Write(ex.StackTrace);
                    }
                }
            } 
        } 
    }
}
