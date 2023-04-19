using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public static class ShipTypeExtensions
    {
        public static int GetSize(this ShipType shipType) => (int)shipType;
    }
}
