using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    public class ControlArea
    {
        string name;
        string baseProj;
        List<int> perimeter;
        List<Cell> cells;

        public ControlArea(string name)
        {
            this.Name = name;
        }

        //Properties
        public string Name { get => name; set => name = value; }
        public string BaseProj { get => baseProj; set => baseProj = value; }

        // Methods
        public List<int> CreatePerimeter()
        {
            return null;
        }

        public void AddCell(string name)
        {
            cells.Add(new Cell(name));
        }

        public bool RemoveCell(string name)
        {
            int idx = cells.FindIndex(x => x.Name == name);
            if (idx >= 0) {
                cells.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
