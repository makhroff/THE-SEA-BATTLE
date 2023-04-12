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

        public void StartGameLoop()
        {
            p1Field.Draw();

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

        private void ArrangeShips()
        {

        }
    }
}
