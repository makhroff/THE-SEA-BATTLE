using System;

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

            player1.cursor.currentPositions = new Vector2[] { new Vector2(3, 3) };
            player1.cursor.SetSize(ShipType.Battleship.GetSize());

            while (gameIsRunning)
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
        }

        private void ProcessInput()
        {
            var input = Console.ReadKey().Key;
            Vector2[] newCoords = new Vector2[player1.cursor.currentPositions.Length];
            hadCursorMoved = false;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    newCoords = CalculateNewCursorCoords(new Vector2(0, -1));
                    break;

                case ConsoleKey.DownArrow:
                    newCoords = CalculateNewCursorCoords(new Vector2(0, 1));
                    break;

                case ConsoleKey.LeftArrow:
                    newCoords = CalculateNewCursorCoords(new Vector2(-1, 0));
                    break;

                case ConsoleKey.RightArrow:
                    newCoords = CalculateNewCursorCoords(new Vector2(1, 0));
                    break;
            }

            if (hadCursorMoved)
                player1.cursor.MoveTo(newCoords);
        }

        private Vector2[] CalculateNewCursorCoords(Vector2 newPos)
        {
            Vector2[] newCoords = new Vector2[player1.cursor.currentPositions.Length];
            for (int i = 0; i < player1.cursor.currentPositions.Length; i++)
            {
                newCoords[i] = player1.cursor.currentPositions[i] + newPos;

                if (newCoords[i].x < 0 || newCoords[i].x >= player1.field.sizeX || newCoords[i].y < 0 || newCoords[i].y >= player1.field.sizeY)
                {
                    return player1.cursor.currentPositions;
                }
            }

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