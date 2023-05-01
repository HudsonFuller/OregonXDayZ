using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    public class Inventory : Item
    {
        public Item[] hands = { null, null };
        public Item clothing = null;
    }

}