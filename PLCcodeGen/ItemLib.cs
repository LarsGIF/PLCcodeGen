using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public class ItemLib
    {
        LibItem root;

        public ItemLib()
        {
            // Create an empty root node
            root = new LibItem("DeviceLib", null, null);
            CreateLib();
        }

        void CreateLib()
        {
            LibItem curLI = root;
            LibItem newLI = new LibItem("ValveIslands", null, root);
            curLI.Children.Add(newLI);
            curLI = newLI;
            ValveIsland island = new ValveIsland("", "CPX");
            island.Components.Add(new Component());
            island.Components.Add(new Component());
            island.Components.Add(new Component());
            island.Components.Add(new Component());
            island.Components.Add(new Component());
            island.Components.Add(new Component());
            island.Components.Add(new Component());
            island.Components.Add(new Component());
            newLI = new LibItem("Festo CPX", island, curLI);
            curLI.Children.Add(newLI);
            this.root
        }
    }

    public class LibItem
    {
        string name;
        Item item;
        LibItem parent;
        IList<LibItem> children;

        public string Name { get => name; set => name = value; }
        public Item Item { get => item; set => item = value; }
        public LibItem Parent { get => parent; set => parent = value; }
        public IList<LibItem> Children { get => children; set => children = value; }

        public LibItem(string name, Item item, LibItem parent)
        {

        }
    }
}
