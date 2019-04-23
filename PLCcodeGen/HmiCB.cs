using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class HmiCB :Item
    {
        #region Constructors
        public HmiCB() { }

        public HmiCB(string name)
            : base(name)
        {
        }
        #endregion
    }
}
