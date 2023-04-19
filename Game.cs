using System;
using System.Collections.Generic;
using System.Linq;
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

    internal class Game
    {
        public static ConsoleColor defaultBackgroundColor = ConsoleColor.DarkBlue;

        private Player player1 = new();

        private GamePhase gamePhase = GamePhase.ShipsArrange;
        private bool gameIsRunning = true;

        private bool hadCursorMoved = false;

        public void StartGameLoop()
        {
            player1.field.DrawCoordinates();
            player1.field.DrawBlankField();
            player1.cursor.MoveTo(new(3, 3));
            player1.cursor.SetSize(2);

            while (gameIsRunning)
            {
                switch(gamePhase)
                {
                    case GamePhase.ShipsArrange:
                        ProcessInput();
                        break;
                    case GamePhase.BattleProcess:
                        break;
                }
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
                player1.cursor.MoveTo(newCoords);
        }

        private Vector2 CalculateNewCursorCoords(Vector2 newPos)
        {
            var newCoords = player1.cursor.currentPosition + newPos;

            if (!AreCoordsWithinField(newCoords, player1.field))
                return player1.cursor.currentPosition;

            hadCursorMoved = true;
            return newCoords;
        }

        public static bool AreCoordsWithinField(Vector2 coords, Field field)
        {
            Vector2 minCoords = new Vector2(-1, -1);
            Vector2 maxCoords = new Vector2(field.sizeX, field.sizeY);

            return coords > minCoords && coords < maxCoords;
        }
    }
}
