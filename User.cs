using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public enum UserType
    {
        Null = 0,
        HumanPlayer = 1,
        Bot = 2
    }
    public class User
    {
        public Field field { get; protected set; } = new(10);
        public Field ennemyField { get; protected set; } = new(10);
        public ConsoleCursor cursor { get; protected set; } = new();

        public string name;
        public static ConsoleColor defaultBackgroundColor = ConsoleColor.Blue;

        public virtual void Setup(string name)
        {
            this.name = name;
        }

        public virtual void ArrangeShips()
        {

        }

    }
}
