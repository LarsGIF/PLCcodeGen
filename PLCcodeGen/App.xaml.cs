﻿using System;
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
            // Temporarily initialize the project tree with some data for testing
            EquipItem v1 = new EquipItem("V1");
            EquipItem v2 = new EquipItem("V2");
            FuncBlock fBlock1 = new FuncBlock("ValveCtrl2");
            FuncBlock fBlock2 = new FuncBlock("ValveCtrl3");
            v1.FBlocks.Add(fBlock1);
            v2.FBlocks.Add(fBlock2);
            Station stn010 = new Station("S010");
            stn010.EquipItems.Add(v1);
            stn010.EquipItems.Add(v2);
            Station stn020 = new Station("S020");
            stn020.EquipItems.Add(v1);
            Cell cell010 = new Cell("C010");
            cell010.Stations.Add(stn010);
            cell010.Stations.Add(stn020);
            Station stn030 = new Station("S030");
            stn030.EquipItems.Add(v1);
            Cell cell030 = new Cell("C030");
            cell030.Stations.Add(stn030);
            Project proj = new Project();
            proj.LineName = "Underbody Line";
            proj.PlcName = "BUB";
            proj.BaseProj = "AZS_16F2T24X";
            proj.Cells.Add(cell010);
            proj.Cells.Add(cell030);
            myProjects.Add(proj);
            
        }
    }
}
