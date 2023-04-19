using Sea_battle;

namespace Sea_battle
{
    public class ConsoleCursor
    {
        public int currentSize;
        private const int maxSize = 4;
        ConsoleColor color = ConsoleColor.White;
        public Vector2[] currentPositions = new Vector2[maxSize];
        Vector2[] oldCentralPositions = new Vector2[maxSize];

        public void MoveTo(Vector2[] newPositions)
        {
            for (int i = 0; i < currentPositions.Length; i++)
            {
                int leftEdge = currentPositions[i].x - (currentSize / 2);
                int rightEdge = currentPositions[i].x + (currentSize / 2);

                if (currentSize % 2 == 0)
                {
                    leftEdge += 1;
                }

                for (int x = leftEdge; x <= rightEdge; x++)
                {
                    Vector2 oldPos = new Vector2(x, currentPositions[i].y);
                    SetColor(oldPos, Game.defaultBackgroundColor);
                }
            }

            currentPositions = newPositions;

            for (int i = 0; i < currentPositions.Length; i++)
            {
                int leftEdge = currentPositions[i].x - (currentSize / 2);
                int rightEdge = currentPositions[i].x + (currentSize / 2);

                if (currentSize % 2 == 0)
                {
                    leftEdge += 1;
                }

                for (int x = leftEdge; x <= rightEdge; x++)
                {
                    Vector2 newPixelPos = new Vector2(x, currentPositions[i].y);
                    SetColor(newPixelPos, ConsoleColor.White);
                }
            }
        }

        public void UpdatePositionInConsole()
        {
            for (int i = 0; i < oldCentralPositions.Length; i++)
            {
                SetCursorPosition(oldCentralPositions[i]);
                Console.BackgroundColor = Game.defaultBackgroundColor;
                Console.Write(" ");
            }

            for (int i = 0; i < currentPositions.Length; i++)
            {
                SetCursorPosition(currentPositions[i]);
                Console.BackgroundColor = color;
                Console.Write(" ");
            }
        }

        void SetCursorPosition(Vector2 pos) => Console.SetCursorPosition(pos.x + Field.startXPos, pos.y + Field.startYPos);
        void SetColor(Vector2 pos, ConsoleColor newColor)
        {
            SetCursorPosition(pos);
            Console.BackgroundColor = newColor;
            Console.Write(" ");
        }

        public void SetSize(int size)
        {
            currentSize = size;

            for (int i = 0; i < currentPositions.Length; i++)
            {
                int leftEdge = currentPositions[i].x - (size / 2);
                int rightEdge = currentPositions[i].x + (size / 2);

                if (size % 2 == 0)
                {
                    leftEdge += 1;
                }

                for (int x = leftEdge; x <= rightEdge; x++)
                {
                    Vector2 position = new Vector2(x, currentPositions[i].y);

                    if (size == 1 || x == currentPositions[i].x || x == leftEdge || x == rightEdge || (size == 4 && (x == currentPositions[i].x - 1 || x == currentPositions[i].x + 1)))
                    {
                        SetColor(position, ConsoleColor.White);
                    }
                    else
                    {
                        SetColor(position, Game.defaultBackgroundColor);
                    }
                }
            }
        }
    }
}