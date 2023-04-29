using Sea_battle.Other;

namespace Sea_battle.Users.Player
{
    public class ConsoleCursor
    {
        ConsoleColor color = ConsoleColor.White;

        public Vector2 currentPosition = new(0, 0);
        private Vector2 oldPosition = new(0, 0);

        private Vector2 offset;

        public ConsoleCursor(Vector2 offset)
        {
            this.offset = offset;
        }

        public void MoveTo(Vector2 newPos)
        {
            oldPosition = currentPosition;
            currentPosition = newPos;
            UpdatePositionInConsole();
        }

        public void UpdatePositionInConsole()
        {
            oldPosition.SetColor(User.defaultBackgroundColor, offset);
            currentPosition.SetColor(color, offset);
        }

        public Vector2 CalculateNewCoords(Vector2 newPos)
        {
            var newCoords = currentPosition + newPos;

            if (!newCoords.AreWithinField())
                return currentPosition;

            return newCoords;
        }
    }
}
