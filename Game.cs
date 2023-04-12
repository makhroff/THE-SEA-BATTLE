using System;
using System.Collections.Generic;
using System.Linq;
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
        private Field p1Field = new(10);

        private GamePhase gamePhase = GamePhase.ShipsArrange;
        private bool gameIsRunning = true;

        private Direction direction;

        public void StartGameLoop()
        {
            p1Field.DrawCoordinates();
            p1Field.DrawBlankField();

            while (gameIsRunning)
            {
                switch(gamePhase)
                {
                    case GamePhase.ShipsArrange:

                        break;
                    case GamePhase.BattleProcess:
                        break;
                }
            }
        }

        private void ProcessInput()
        {
            var input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;

                 case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
            }
        }

        private void ArrangeShips()
        {
            
        }
    }
}
