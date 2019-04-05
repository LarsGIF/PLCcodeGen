using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PLCcodeGen
{
    [Serializable]
    class PneuCyl : Item
    {
        private string sensBxF;
        private string sensBxR;

        public PneuCyl(string name) : base(name)
        {
            base.Name = name;
            if (Name[0] == 'C')
            {
                Name.Replace('C', 'c');
                this.Name = Name;
            }

            if (Name[0] == 'c')
            {
                String[] split = Regex.Split(Name, @"\w*\d*\w*");
                this.sensBxF = "Bc" + split[1] + split[2] + "F";
                this.sensBxR = "Bc" + split[1] + split[2] + "R";
            }
        }

        public PneuCyl(string name, string valve, string sensBxF, string sensBxR) : base(name)
        {
            this.sensBxF = sensBxF;
            this.sensBxR = sensBxR;
        }

        public string SensBxF { get => sensBxF; set => sensBxF = value; }
        public string SensBxR { get => sensBxR; set => sensBxR = value; }
    }
}
