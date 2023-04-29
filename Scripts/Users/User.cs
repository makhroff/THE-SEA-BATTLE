using Sea_battle.Field_;
using Sea_battle.Other;

namespace Sea_battle.Users
{
    public enum UserType
    {
        Null = 0,
        HumanPlayer = 1,
        Bot = 2
    }
    public abstract class User
    {
        public Field field { get; protected set; } = new(10);
        public Field ennemyField { get; protected set; } = new(10);

        public static ConsoleColor defaultBackgroundColor = ConsoleColor.Blue;
        public string name = "";
        public int shipsLeft;

        protected Vector2 ennemyFieldOffset = new(0, 1);
        protected Vector2 personnalFieldOffset = new(0, 0);

        private List<Vector2> shipCoordsList = new();

        public virtual void Setup(string name, Field ennemyField)
        {
            this.name = name;
            this.ennemyField = ennemyField;
            personnalFieldOffset = new(0, field.size + ennemyFieldOffset.y + 3);
        }

        public void ArrangeShips(int shipsToArrange)
        {
            shipsLeft = shipsToArrange;

            for(int i = 0; i < shipsToArrange; i++)
            {
                var shipCoords = GetNewRandomCoord();
                field.AddShip(shipCoords);
            }
        }

        private Vector2 GetNewRandomCoord()
        {
            var shipCoords = Vector2.GetRandomCoordinates(10, 10);

            if (!shipCoordsList.ContainsVector(shipCoords))
            {
                shipCoordsList.Add(shipCoords);
                return shipCoords;
            }
            else
            {
                return GetNewRandomCoord();
            }
        }

        public abstract void MakeMove();

        public void TryToHitEnnemy(Vector2 coordinatesToHit, out bool isHitSuccessful)
        {
            if (ennemyField.HadMarkedCell(coordinatesToHit))
            {
                isHitSuccessful = true;
                return;
            }

            isHitSuccessful = ennemyField.DoesCellHaveShip(coordinatesToHit);

            if (isHitSuccessful)
            {
                shipsLeft--;
                ennemyField.MarkCell(coordinatesToHit, CellValueType.HitWithSuccess);
            }
            else
            {
                ennemyField.MarkCell(coordinatesToHit, CellValueType.HitWithFailure);
            }
        }

        public virtual void DrawPersonnalField()
        {
            Console.SetCursorPosition(0, personnalFieldOffset.y - 1);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Your field");
            Console.ForegroundColor = ConsoleColor.White;

            field.DrawCoordinates(personnalFieldOffset);
            field.DrawBlankField(personnalFieldOffset);
            field.DrawShipsOnField(personnalFieldOffset);
            field.DrawMarkedCells(personnalFieldOffset);
        }

        public virtual void DrawEnnemyField()
        {
            Console.SetCursorPosition(0, ennemyFieldOffset.y - 1);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Ennemy's field");
            Console.ForegroundColor = ConsoleColor.White;

            ennemyField.DrawCoordinates(ennemyFieldOffset);
            ennemyField.DrawBlankField(ennemyFieldOffset);
            ennemyField.DrawMarkedCells(ennemyFieldOffset);
        }
    }
}
