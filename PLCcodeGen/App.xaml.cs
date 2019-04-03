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
            // Temporarily initialize the project tree with some data for testing
            Item auCtrl = new Item("S010au") {ItemType = TypeOfItem.mfBlock};
            FuncBlock seqFB = new FuncBlock("S010seq");
            auCtrl.FBlocks.Add(seqFB);
            Item c1a = new Item("C1a") {ItemType = TypeOfItem.cylinder};
            Item c1b = new Item("C1b") {ItemType = TypeOfItem.cylinder};
            Item c1c = new Item("C1c") { ItemType = TypeOfItem.cylinder };
            Item v1 = new Item("V1") {ItemType = TypeOfItem.valve};
            c1a.ParentItem = v1;
            c1b.ParentItem = v1;
            FuncBlock vCtrl2 = new FuncBlock("ValveCtrl2");
            v1.FBlocks.Add(vCtrl2);
            Item c2a = new Item("C2a") {ItemType = TypeOfItem.cylinder};
            Item c2b = new Item("C2b") {ItemType = TypeOfItem.cylinder};
            Item c2c = new Item("C2c") {ItemType = TypeOfItem.cylinder};
            Item v2 = new Item("V2") {ItemType = TypeOfItem.valve};
            c2a.ParentItem = v2;
            c2b.ParentItem = v2;
            c2c.ParentItem = v2;
            FuncBlock vCtrl3 = new FuncBlock("ValveCtrl3");
            v2.FBlocks.Add(vCtrl3);
            Station stn010 = new Station("S010");
            stn010.Items.Add(auCtrl);
            stn010.Items.Add(c1a);
            stn010.Items.Add(c1b);
            stn010.Items.Add(c2a);
            stn010.Items.Add(c2b);
            stn010.Items.Add(c2c);
            stn010.Items.Add(v1);
            stn010.Items.Add(v2);
            Station stn020 = new Station("S020");
            auCtrl = new Item("S020au") {ItemType = TypeOfItem.mfBlock};
            stn020.Items.Add(auCtrl);
            stn020.Items.Add(c1a);
            stn020.Items.Add(c1b);
            stn020.Items.Add(c1c);
            v1 = new Item("V1") { ItemType = TypeOfItem.valve };
            v1.FBlocks.Add(vCtrl3);
            c1a.ParentItem = v1;
            c1b.ParentItem = v1;
            c1c.ParentItem = v1;
            stn020.Items.Add(v1);
            Item g1 = new Item("G1") {ItemType = TypeOfItem.aGate};
            Item ah1 = new Item("AH1") {ItemType = TypeOfItem.hCB};
            Item mode = new Item("Mode") {ItemType = TypeOfItem.mfBlock};
            FuncBlock fBlockMode = new FuncBlock("ModeSelect");
            mode.FBlocks.Add(fBlockMode);
            Cell cell010 = new Cell("C010");
            cell010.Items.Add(g1);
            cell010.Items.Add(ah1);
            cell010.Items.Add(mode);
            cell010.Stations.Add(stn010);
            cell010.Stations.Add(stn020);
            Station stn030 = new Station("S030");
            auCtrl = new Item("S030au") { ItemType = TypeOfItem.mfBlock };
            stn030.Items.Add(auCtrl);
            stn030.Items.Add(c1a);
            stn030.Items.Add(c1b);
            stn030.Items.Add(v1);
            Cell cell030 = new Cell("C030");
            cell030.Items.Add(g1);
            cell030.Items.Add(ah1);
            cell030.Items.Add(mode);
            cell030.Stations.Add(stn030);
            Project proj = new Project
            {
                LineName = "Underbody Line",
                PlcName = "BUB",
                BaseProj = "AZS_16F2T24X"
            };
            proj.Cells.Add(cell010);
            proj.Cells.Add(cell030);
            Item az1 = new Item("AZ1") {ItemType = TypeOfItem.encapulation};
            Item dh1 = new Item("DH1") {ItemType = TypeOfItem.hmi};
            proj.Items.Add(az1);
            proj.Items.Add(dh1);
            myProjects.Add(proj);
        }
    }
}
