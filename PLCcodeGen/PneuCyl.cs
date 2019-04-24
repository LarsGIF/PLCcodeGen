using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class PneuCyl : Item
    {
        private string sensBxF;
        private string sensBxR;

        #region Properties Getters and Setters
        public string SensBxF { get => sensBxF; set => sensBxF = value; }
        public string SensBxR { get => sensBxR; set => sensBxR = value; }
        #endregion

        #region Contructors
        public PneuCyl()
        {
            base.ItemType = TypeOfItem.cylinder;
        }

        public PneuCyl(string name) 
            : base(name)
        {
            base.ItemType = TypeOfItem.cylinder;
            string temp = Name.Substring(1);

            if (Name[0] == 'c')
            {
                Name = "C" + temp;
            }

            if (Name[0] == 'C')
            {
                this.sensBxF = "Bc" + temp + "F";
                this.sensBxR = "Bc" + temp + "R";
            }
        }

        public PneuCyl(string location, string name) 
            : base(name)
        {
            base.ItemType = TypeOfItem.cylinder;
            string temp = Name.Substring(1);

            if (Name[0] == 'c')
            {
                Name = "C" + temp;
            }

            if (Name[0] == 'C') { 
                this.sensBxF = location + "Bc" + temp + "F";
                this.sensBxR = location + "Bc" + temp + "R";
            }
        }

        public PneuCyl(string name, string valve, string sensBxF, string sensBxR) 
            : base(name)
        {
            base.ItemType = TypeOfItem.cylinder;
            this.sensBxF = sensBxF;
            this.sensBxR = sensBxR;
        }
        #endregion
    }
}
