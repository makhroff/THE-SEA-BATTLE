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

        public static int startXPos = 3;
        public static int startYPos = 1;

        public int sizeX { get; private set; }
        public int sizeY { get; private set; }
        public Field(int size)
        {
            sizeX = size;
            sizeY = size;
            _cells = new Cell[sizeX, sizeY];
            InitField();
        }

        private void InitField()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    var cell = _cells[x, y] = new Cell();
                    cell.Value = null;
                }
            }
        }

        public void DrawBlankField()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    Console.SetCursorPosition(x + startXPos, y + startYPos);
                    Console.BackgroundColor = _cells[x, y].Color;
                    Console.Write(' ');
                }

                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void DrawCoordinates()
        {
            Console.Write("   ");

            for (int x = 0; x < sizeX; x++)
            {
                Console.Write((char)(x + 'A'));
            }

            Console.WriteLine();

            for(int y = 0; y < sizeY; y++)
            {
                var offset = (y + 1) >= 10 ? string.Empty : " ";
                Console.WriteLine(offset + (y + 1) + " ");
            }
        }
    }
}
