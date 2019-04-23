using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class Motor : Item
    {
        #region Properties Getters and Setters
        #endregion

        #region Constructors
        public Motor() { }

        public Motor(string name)
            : base(name)
        {
        }
        #endregion
    }
}
