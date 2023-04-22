namespace Sea_battle
{
    public class ConsoleCursor
    {
        ConsoleColor color = ConsoleColor.White;
        public Vector2 currentPosition = new(0, 0);
        Vector2 oldPosition = new(0, 0);

        public void MoveTo(Vector2 newPos)
        {
            oldPosition = currentPosition;
            currentPosition = newPos;
            UpdatePositionInConsole();
        }

        public void UpdatePositionInConsole()
        {
            SetCursorPosition(oldPosition);
            Console.BackgroundColor = Game.defaultBackgroundColor;
            Console.Write(" ");
            SetCursorPosition(currentPosition);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }

        void SetCursorPosition(Vector2 pos) => Console.SetCursorPosition(pos.x + Field.startXPos, pos.y + Field.startYPos);
    }
}
