using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    class FuncBlock
    {
        public enum CodeType {std, safe};
        string name;
        string ver;
        CodeType ct;
        string def;
        string connRules;

        public FuncBlock(string name)
        {
            this.name = name;
        }

        public FuncBlock(string name, string ver, CodeType ct, string def, string connRules)
        {
            this.name = name;
            this.ver = ver;
            this.ct = ct;
            this.def = def;
            this.connRules = connRules;
        }

        public string Name { get => name; set => name = value; }
        public string Ver { get => ver; set => ver = value; }
        private CodeType Ct { get => ct; set => ct = value; }
        public string Def { get => def; set => def = value; }
        public string ConnRules { get => connRules; set => connRules = value; }
    }
}
