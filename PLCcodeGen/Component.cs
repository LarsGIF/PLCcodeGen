using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class Component
    {
        string name;
        string orderNumber;
        ComponentType type;
        string description;

        #region Properties Getters and Setters
        public string Name { get => name; set => name = value; }
        public string OrderNumber { get => orderNumber; set => orderNumber = value; }
        public ComponentType Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region Constructors
        public Component() { }

        public Component(string name, string orderNum, ComponentType type, string description)
        {
            this.name = name;
            this.orderNumber = orderNum;
            this.type = type;
            this.description = description;
        }
        #endregion
    }

    public enum ComponentType
    {
        undef,      // undefined
        misc,       // miscelaneous module e.g. mechanical
        commMod,    // communication node module
        inpMod,     // input module
        inOutMod,   // combined input and output module
        outMod,     // output module
        valve1Mod,  // single solenoid valve
        valve2Mod   // double solenoid valve
    };
}
