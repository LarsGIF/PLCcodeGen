using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class Valve : Item
    {
        string type;
        List<PneuCyl> pneuCyls;

        #region Properties Getters and Setters
        public string Type { get => type; set => type = value; }
        public List<PneuCyl> PneuCyls { get => pneuCyls; set => pneuCyls = value; }
        #endregion

        #region Constructors
        public Valve()
        {
            base.ItemType = TypeOfItem.valve;
        }

        public Valve(string name) 
            : base(name)
        {
            base.ItemType = TypeOfItem.valve;
        }
        #endregion
    }
}
