using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    class Valve : Item
    {
        string type;
        List<PneuCyl> pneuCyls;

        public string Type { get => type; set => type = value; }
        internal List<PneuCyl> PneuCyls { get => pneuCyls; set => pneuCyls = value; }

        public Valve(string name) : base(name)
        {
            base.Name = name;
        }
    }
}
