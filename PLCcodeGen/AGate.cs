using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class AGate : Item
    {
        #region Properties Getters and Setters
        #endregion

        #region Constructors
        public AGate() {}

        public AGate (string name) 
            : base(name)
        {
        }
        #endregion
    }
}
