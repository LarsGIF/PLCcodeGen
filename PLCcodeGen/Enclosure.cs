﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCcodeGen
{
    [Serializable]
    public class Enclosure : Item
    {
        #region Properties Getters and Setters
        #endregion

        #region Constructors
        public Enclosure() {}

        public Enclosure(string name)
            : base(name)
        {
        }
        #endregion
    }
}
