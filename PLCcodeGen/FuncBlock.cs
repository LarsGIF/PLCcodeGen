using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class FuncBlock
    {
        private string typeName;
        private string ver;
        private InstanceType instType;
        private TypeOfCode cdeType;
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
        public InstanceType InstType
        {
            get => instType;
            set => instType = value;
        }
        public TypeOfCode CdeType
        {
            get => cdeType;
            set => cdeType = value;
        }
        public string ConnRules
        {
            get => connRules;
            set => connRules = value;
        }
        #endregion

        #region Constructors
        public FuncBlock() {}

        public FuncBlock(string typeName)
        {
            this.typeName = typeName;
        }

        public FuncBlock(string typeName, string ver, TypeOfCode cdeType, string connRules)
        {
            this.ver = ver;
            this.cdeType = cdeType;
            this.typeName = typeName;
            this.connRules = connRules;
        }
        #endregion
    }

    public enum InstanceType
    {
        undefined,  // Undefined item (default if not defined)
        single,     // Single instance FB (program)
        multi,      // Multi instance FB (normal FB)
        sfc         // Sequencial Function Chart
    };

    public enum TypeOfCode
    {
        std,        // Standard progarm
        safe        // Failsafe program
    };
}
