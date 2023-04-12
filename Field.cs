using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public class Field
    {
        private Cell[,] _cells;
        public int sizeX { get; private set; }
        public int sizeY { get; private set; }
        public Field(int size)
        {
            sizeX = size;
            sizeY = size;
            InitField();
        }

        private void InitField()
        {
            _cells = new Cell[sizeX, sizeY];

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    var cell = _cells[x, y] = new Cell();
                    cell.Value = ' ';
                }
            }
        }

        public void Draw()
        {
            Console.Write("   ");

            for (int x = 0; x < sizeX; x++)
            {
                Console.Write((char)(x + 'A'));
            }

            Console.WriteLine();

            for (int y = 0; y < sizeY; y++)
            {
                var offset = (y + 1) >= 10 ? string.Empty : " ";
                Console.Write(offset + (y + 1) + " ");

                for (int x = 0; x < sizeX; x++)
                {
                    Console.BackgroundColor = _cells[x, y].Color;
                    Console.Write(_cells[x, y].Value);
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
    }
}
