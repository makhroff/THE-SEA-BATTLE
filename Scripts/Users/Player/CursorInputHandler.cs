using Sea_battle.Other;
using Sea_battle.Users.Player;

namespace Sea_battle.Users.Player
{
    public class PlayerInputHandler
    {
        public ConsoleCursor cursor { private set; get; }
        private HumanPlayer player;

        public PlayerInputHandler(HumanPlayer player, Vector2 cursorOffset)
        {
            this.player = player;
            cursor = new(cursorOffset);
        }

        public void TryToProcessInputOrHitEnnemy(out bool isOperationSuccessful)
        {
            var input = Console.ReadKey().Key;
            isOperationSuccessful = true;

            Vector2 newCoords = cursor.currentPosition;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    newCoords = cursor.CalculateNewCoords(new(0, -1));
                    break;

                case ConsoleKey.DownArrow:
                    newCoords = cursor.CalculateNewCoords(new(0, 1));
                    break;

                case ConsoleKey.LeftArrow:
                    newCoords = cursor.CalculateNewCoords(new(-1, 0));
                    break;

                case ConsoleKey.RightArrow:
                    newCoords = cursor.CalculateNewCoords(new(1, 0));
                    break;

                case ConsoleKey.Enter:
                    player.TryToHitEnnemy(cursor.currentPosition, out isOperationSuccessful);
                    break;
            }

            cursor.MoveTo(newCoords);
        }
    }
}
