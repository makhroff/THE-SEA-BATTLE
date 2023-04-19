using Sea_battle;

namespace Sea_battle
{
    public class ConsoleCursor
    {
        private int currentSize;
        private const int maxSize = 4;
        ConsoleColor color = ConsoleColor.White;
        public Vector2 currentPosition = new(0, 0);
        Vector2 oldCentralPosition = new(0, 0);

        public void MoveTo(Vector2 newPos)
        {
            int leftEdge = currentPosition.x - (currentSize / 2);
            int rightEdge = currentPosition.x + (currentSize / 2);

            if (currentSize % 2 == 0)
            {
                leftEdge += 1;
            }

            for (int x = leftEdge; x <= rightEdge; x++)
            {
                Vector2 oldPos = new Vector2(x, currentPosition.y);
                SetColor(oldPos, Game.defaultBackgroundColor);
            }

            currentPosition = newPos;

            leftEdge = currentPosition.x - (currentSize / 2);
            rightEdge = currentPosition.x + (currentSize / 2);

            if (currentSize % 2 == 0)
            {
                leftEdge += 1;
            }

            for (int x = leftEdge; x <= rightEdge; x++)
            {
                Vector2 newPixelPos = new Vector2(x, currentPosition.y);
                SetColor(newPixelPos, ConsoleColor.White);
            }
        }

        public void UpdatePositionInConsole()
        {
            SetCursorPosition(oldCentralPosition);
            Console.BackgroundColor = Game.defaultBackgroundColor;
            Console.Write(" ");
            SetCursorPosition(currentPosition);
            Console.BackgroundColor = color;
            Console.Write(" ");
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
            int leftEdge = currentPosition.x - (size / 2);
            int rightEdge = currentPosition.x + (size / 2);

            if (size % 2 == 0)
            {
                leftEdge += 1;
            }

            for (int x = leftEdge; x <= rightEdge; x++)
            {
                Vector2 position = new Vector2(x, currentPosition.y);

                if (size == 1 || x == currentPosition.x || x == leftEdge || x == rightEdge || (size == 4 && (x == currentPosition.x - 1 || x == currentPosition.x + 1)))
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
