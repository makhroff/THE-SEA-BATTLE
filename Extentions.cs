using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public static class Extentions
    {
        public static void SetColor(this Vector2 pos, ConsoleColor color)
        {
            SetCursorPosition(pos);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }

        /// <summary>
        /// Sets cursor position with field coordinates offset.
        /// </summary>
        /// <param name="pos"></param>
        public static void SetCursorPosition(Vector2 pos) 
            => Console.SetCursorPosition(pos.x + Field.startXPos, pos.y + Field.startYPos);

        public static User GetNewUser(this UserType type) => type switch
        {
            UserType.HumanPlayer => new HumanPlayer(),
            UserType.Bot => new Bot(),
            _ => new User()
        };
    }
}
