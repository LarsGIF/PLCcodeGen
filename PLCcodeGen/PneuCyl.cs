using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PLCcodeGen
{
    class PneuCyl : EquipItem
    {
        string name;
        string valve;
        string sensBxF;
        string sensBxR;

        public PneuCyl(string name) : base(name)
        {
            String Name = name;
            if (Name[0] == 'C')
            {
                Name.Replace('C', 'c');
                this.name = Name;
            }
            if (Name[0] == 'c')
            {
                String[] split = Regex.Split(Name, @"\w*\d*\w*");
                this.valve = "V" + split[1];
                this.sensBxF = "Bc" + split[1] + split[2] + "F";
                this.sensBxR = "Bc" + split[1] + split[2] + "R";
            }
            else ;
        }

        public PneuCyl(string name, string valve, string sensBxF, string sensBxR) : base(name)
        {
            this.valve = valve;
            this.sensBxF = sensBxF;
            this.sensBxR = sensBxR;
        }

        public string Name { get => name; set => name = value; }
        public string Valve { get => valve; set => valve = value; }
        public string SensBxF { get => sensBxF; set => sensBxF = value; }
        public string SensBxR { get => sensBxR; set => sensBxR = value; }
    }
}
