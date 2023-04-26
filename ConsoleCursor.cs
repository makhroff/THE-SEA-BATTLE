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
            oldPosition.SetColor(User.defaultBackgroundColor);
            currentPosition.SetColor(color);
        }
    }
}
