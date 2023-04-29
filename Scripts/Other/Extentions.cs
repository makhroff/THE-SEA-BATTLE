using Sea_battle.Users;
using Sea_battle.Users.Player;
using Sea_battle.Field_;

namespace Sea_battle.Other
{
    public static class Extentions
    {
        public static void SetColor(this Vector2 pos, ConsoleColor color, Vector2 offset)
        {
            SetCursorPosition(pos + offset);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }
        public static void Write(this Vector2 pos, string symbol, Vector2 offset)
        {
            SetCursorPosition(pos + offset);
            Console.Write(symbol);
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
            UserType.Bot => new Bot()
        };

        public static bool AreWithinField(this Vector2 coords)
        {
            Vector2 minCoords = new Vector2(-1, -1);
            Vector2 maxCoords = new Vector2(10, 10);

            return coords > minCoords && coords < maxCoords;
        }

        public static bool ContainsVector(this List<Vector2> list, Vector2 coordToVerify)
        {
            foreach(var coord in list)
            {
                if(coord == coordToVerify)
                    return true;
            }
            return false;
        }
    }
}
