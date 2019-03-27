using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public enum IOtype { inp, outp, inOut}

    class ValveIsland : Item
    {
        List<Module> modules;
        List<string> valves;

        public ValveIsland(string name, bool baseConfig) : base(name)
        {
            if (baseConfig)
            {
                // Minimum configuration for a valve island comprise: 
                // one input module, one safety output module and one pilot air valve
                modules.Add(new Module(""));
                modules.Add(new Module(""));
                valves.Add("V0");
            }
        }

        public void AddModule(string name)
        {
            modules.Add(new Module(name));
        }

        public void InsertModule(string name)
        {
            // Insert a new module before the last module
            Module newModule = new Module(name);
            Module last = modules[modules.Count-1];
            modules.Add(last);
            modules[modules.Count-2] = newModule;
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

        public void AddValve()
        {
            valves.Add("V" + valves.Count);
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

    class Module
    {
        string name;
        List<IO> ios;

        public Module(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

        public void AddIO(string name, IOtype ioType,string adr, string varType,string comment)
        {
            IO io = new IO(name);
            io.IoType = ioType;
            io.Adr = adr;
            io.VarType = varType;
            io.Comment = comment;
            ios.Add(io);
        }

        public bool RemoveIO(string name)
        {
            int idx = ios.FindIndex(x => x.Name == name);
            if (idx >= 0)
            {
                ios.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }

    class IO
    {
        string name;
        IOtype ioType;
        string adr;
        string varType;
        string comment;

        public IO(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public IOtype IoType { get => ioType; set => ioType = value; }
        public string Adr { get => adr; set => adr = value; }
        public string VarType { get => varType; set => varType = value; }
        public string Comment { get => comment; set => comment = value; }
    }
}
