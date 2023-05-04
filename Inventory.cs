using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    public class Inventory : Item
    {
        // declares two hands and one item of clothing, must be set to null
        public Item[] hands = { null, null };
        public Item clothing = null;
    }

}