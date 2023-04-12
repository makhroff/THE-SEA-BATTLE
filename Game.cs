using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    internal class Game
    {
        private Field p1Field = new(10);

        public void StartGameLoop()
        {
            p1Field.Draw();
        }

        private void ArrangeShips()
        {

        }
    }
}
