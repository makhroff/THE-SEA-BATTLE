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

        public ConsoleColor BackgroundColor = ConsoleColor.Blue;

        public static int startXPos = 3;
        public static int startYPos = 1;

        public int size = 10;
        public Field(int size)
        {
            this.size = size;
            _cells = new Cell[this.size, this.size];
            InitField();
        }

        private void InitField()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    var cell = _cells[x, y] = new Cell();
                    cell.Value = null;
                }
            }
        }

        public void DrawBlankField()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    new Vector2(x, y).SetColor(BackgroundColor);
                }

                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void DrawCoordinates()
        {
            Console.Write("   ");

            for (int x = 0; x < size; x++)
            {
                Console.Write((char)(x + 'A'));
            }

            Console.WriteLine();

            for(int y = 0; y < size; y++)
            {
                var offset = (y + 1) >= 10 ? string.Empty : " ";
                Console.WriteLine(offset + (y + 1) + " ");
            }
        }
    }
}