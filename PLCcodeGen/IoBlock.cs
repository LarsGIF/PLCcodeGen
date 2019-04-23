using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class IoBlock : Item
    {
        #region Properties Getters and Setters
        #endregion

        #region Constructors
        public IoBlock() { }

        public IoBlock(string name)
            : base(name)
        {
        }
        #endregion
    }
}
