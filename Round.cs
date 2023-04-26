using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public enum GamePhase
    {
        ShipsArrange,
        BattleProcess
    }
    public enum RoundWinner
    {
        User1,
        User2
    }

    public class Round
    {   
        private User currentUser = new();
        private User user1;
        private User user2;

        private GamePhase gamePhase = GamePhase.ShipsArrange;
        private bool gameIsRunning = true;

        private bool hadCursorMoved = false;

        public Round(UserType userType1, UserType userType2)
        {
            user1 = userType1.GetNewUser();
            user2 = userType2.GetNewUser();
        }

        public void StartGameLoop(out RoundWinner winner)
        {
            user1.Setup("KARL");

            currentUser = user1;
            currentUser.Setup("BUBLIK");
            SwitchCurrentUser();

            Console.WriteLine(user1.name);

            while (gameIsRunning)
            {
                MakeMove();
                SwitchCurrentUser();
            }

            winner = RoundWinner.User1;
        }

        private void MakeMove()
        {
            switch (gamePhase)
            {
                case GamePhase.ShipsArrange:
                    ProcessInput();
                    break;
                case GamePhase.BattleProcess:
                    break;
            }
        }

        private void ProcessInput()
        {
            var input = Console.ReadKey().Key;
            Vector2 newCoords = new(0, 0);
            hadCursorMoved = false;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    newCoords = CalculateNewCursorCoords(new(0, -1));
                    break;

                case ConsoleKey.DownArrow:
                    newCoords = CalculateNewCursorCoords(new(0, 1));
                    break;

                case ConsoleKey.LeftArrow:
                    newCoords = CalculateNewCursorCoords(new(-1, 0));
                    break;

                 case ConsoleKey.RightArrow:
                    newCoords = CalculateNewCursorCoords(new(1, 0));
                    break;
            }

            if (hadCursorMoved)
                currentUser.cursor.MoveTo(newCoords);
        }

        private Vector2 CalculateNewCursorCoords(Vector2 newPos)
        {
            var newCoords = currentUser.cursor.currentPosition + newPos;

            if (!AreCoordsWithinField(newCoords))
                return currentUser.cursor.currentPosition;

            hadCursorMoved = true;
            return newCoords;
        }

        private void SwitchCurrentUser()
            => currentUser = (currentUser == user1) ? user2 : user1;

        public bool AreCoordsWithinField(Vector2 coords)
        {
            Vector2 minCoords = new Vector2(-1, -1);
            Vector2 maxCoords = new Vector2(currentUser.field.size, currentUser.field.size);

            return coords > minCoords && coords < maxCoords;
        }
    }
}
