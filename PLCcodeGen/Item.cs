using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    class Item
    { 
        String name;
        List<FuncBlock> fBlocks;

        public Item(String name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

        public void AddFBlock(String name)
        {
            fBlocks.Add(new FuncBlock(name));
        }

        public bool RemoveFBlock(String name)
        {
            int idx = fBlocks.FindIndex(x => x.Name == name);
            if (idx >= 0)
            {
                fBlocks.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
