using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public class FuncBlock
    {
        private string typeName;
        private string ver;
        private CodeType cdeType;
        private string def;
        private string connRules;

        #region  Properties Getters and Setters
        public string TypeName
        {
            get => typeName;
            set => typeName = value;
        }
        public string Ver
        {
            get => ver;
            set => ver = value;
        }
        public CodeType CdeType
        {
            get => cdeType;
            set => cdeType = value;
        }
        public string Def
        {
            get => def;
            set => def = value;
        }
        public string ConnRules
        {
            get => connRules;
            set => connRules = value;
        }
        #endregion

        #region Constructors
        public FuncBlock(string typeName)
        {
            this.typeName = typeName;
        }

        public FuncBlock(string name, string ver, CodeType cdeType, string def, string connRules)
        {
            this.typeName = name;
            this.ver = ver;
            this.cdeType = cdeType;
            this.def = def;
            this.connRules = connRules;
        }
        #endregion
    }

    public enum CodeType {std, safe};
}
