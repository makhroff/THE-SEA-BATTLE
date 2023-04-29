using Sea_battle.Other;

namespace Sea_battle.Field_
{
    public static class FieldRendererExtention
    {
        public static void DrawBlankField(this Field field, Vector2 offset)
        {
            for (int y = 0; y < field.size; y++)
            {
                for (int x = 0; x < field.size; x++)
                {
                    new Vector2(x, y).SetColor(field.BackgroundColor, offset);
                }

                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static void DrawMarkedCells(this Field field, Vector2 offset)
        {
            foreach(var markedCellCoords in field.markedCellsCoordinates)
            {
                markedCellCoords.SetColor(field.cells[markedCellCoords.x, markedCellCoords.y].Color, offset);

                switch(field.cells[markedCellCoords.x, markedCellCoords.y].Value)
                {
                    case CellValueType.HitWithSuccess:
                        markedCellCoords.Write("X", offset); 
                        break;
                    case CellValueType.HitWithFailure:
                        markedCellCoords.Write("o", offset);
                        break;
                }
            }
        }

        public static void DrawShipsOnField(this Field field, Vector2 offset)
        {
            foreach (var shipCoord in field.shipsCoordinates)
            {
                shipCoord.SetColor(ConsoleColor.Red, offset);
            }
        }

        public static void DrawCoordinates(this Field field, Vector2 offset)
        {
            Console.SetCursorPosition(0, offset.y);
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("   ");

            for (int x = 0; x < field.size; x++)
            {
                Console.Write((char)(x + 'A'));
            }

            Console.WriteLine();

            for (int y = 0; y < field.size; y++)
            {
                var stringOffset = (y + 1) >= 10 ? string.Empty : " ";
                Console.WriteLine(stringOffset + (y + 1) + " ");
            }
        }
    }
}