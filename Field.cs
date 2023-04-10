using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public class Field
    {
        private Cell[,] cells;

        public Field(int size) 
        { 
            cells = new Cell[size, size * 2];
        }
    }
}
