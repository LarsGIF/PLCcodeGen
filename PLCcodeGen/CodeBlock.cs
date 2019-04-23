using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class CodeBlock : Item
    {
        #region Constructors
        public CodeBlock() {}

        public CodeBlock(string name)
            : base(name)
        {
        }
        #endregion
    }
}
