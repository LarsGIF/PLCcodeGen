using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public enum IOtype { inp, outp, inOut}

    [Serializable]
    public class ValveIsland : Item
    {
        List<Module> modules = new List<Module>();
        List<Valve> valves = new List<Valve>();
        List<Component> components = new List<Component>();

        #region Properties Getters and Setters
        public List<Module> Modules { get => modules; set => modules = value; }
        public List<Valve> Valves { get => valves; set => valves = value; }
        public List<Component> Components { get => components; set => components = value; }
        #endregion

        #region Constructors
        public ValveIsland()
        {
            base.ItemType = TypeOfItem.valveIsland;
        }

        public ValveIsland(string location, string name) 
            : base(name)
        {
            base.ItemType = TypeOfItem.valveIsland;

            // Minimum configuration for a valve island comprise: 
            // one communication module, one input module, one safety output module and one pilot air valve
            // TODO: Add communication module ".0".
            modules.Add(new Module(name + ".1", 8, IOtype.inp, "bool"));
            modules[0].Ios[0].Name = location + "Bv0F";
            modules.Add(new Module(name + ".2", 3, IOtype.outp, "bool"));
            modules[1].Ios[0].Name = location + "YvOn"; // TODO: May not be correct
            valves.Add(new Valve("V0")); // Pilot air valve.
        }
        #endregion

        public int InsertModule(string name, int size, IOtype ioType, string varType)
        {
            Module last = modules[modules.Count-1];

            // Adjust output module name and add a copy. 
            last.Name = name + "." + (modules.Count);
            modules.Add(last);

            // Insert a new module before the last module
            modules[modules.Count-2] = new Module(name + "." + (modules.Count-2), size, ioType, varType);

            // Return index to new module
            return modules.Count-2;
        }

        public bool RemoveModule(string name)
        {
            int idx = modules.FindIndex(x => x.Name == name);
            if (idx >= 0)
            {
                modules.RemoveAt(idx);
                return true;
            }
            return false;
        }

        public bool RemoveValve()
        {
            if (valves.Count > 0)
            {
                modules.RemoveAt(modules.Count-1);
                return true;
            }
            return false;
        }
    }

    [Serializable]
    public class Module
    {
        string name;
        int size;
        List<IO> ios;

        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        public List<IO> Ios { get => ios; set => ios = value; }

        #region Constructors
        public Module() { }

        public Module(string name, int size, IOtype ioType, string varType)
        {
            this.name = name;
            this.size = size;
            this.ios = new List<IO>();
            for(int i = 0; i < size; i++)
            {
                this.ios.Add(new IO(ioType, varType));
            }
        }
        #endregion
    }

    [Serializable]
    public class IO
    {
        string name;    // variable name
        IOtype ioType;  // enum type
        string adr;     
        string varType; // e.g. bool
        string comment;

        public string Name { get => name; set => name = value; }
        public IOtype IoType { get => ioType; set => ioType = value; }
        public string Adr { get => adr; set => adr = value; }
        public string VarType { get => varType; set => varType = value; }
        public string Comment { get => comment; set => comment = value; }

        public IO() { }

        public IO(IOtype ioType, string varType)
        {
            this.ioType = ioType;
            this.varType = varType;
        }
    }
}
