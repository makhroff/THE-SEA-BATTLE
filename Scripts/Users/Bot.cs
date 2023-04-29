using Sea_battle.Other;
using Sea_battle.Field_;

namespace Sea_battle.Users
{
    public class Bot : User
    {
        private List<Vector2> hitCoordinates = new();

        public override void MakeMove()
        {
            //DrawPersonnalField();
            DrawEnnemyField();

            bool userHitEnnemy = true;

            while (userHitEnnemy)
            {
                var coord = GetNewCoordToHit();
                TryToHitEnnemy(coord, out userHitEnnemy);

                //field.DrawMarkedCells(personnalFieldOffset);
                ennemyField.DrawMarkedCells(ennemyFieldOffset);
            }

            Console.ReadKey();
        }

        private Vector2 GetNewCoordToHit()
        {
            var newCoordToHit = Vector2.GetRandomCoordinates(10, 10);

            if (!hitCoordinates.ContainsVector(newCoordToHit))
            {
                hitCoordinates.Add(newCoordToHit);
                return newCoordToHit;
            }
            else
            {
                return GetNewCoordToHit();
            }
        }
    }
}
