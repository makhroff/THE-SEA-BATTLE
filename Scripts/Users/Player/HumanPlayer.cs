using Sea_battle.Users;
using Sea_battle.Users.Player;
using Sea_battle.Field_;

namespace Sea_battle.Users.Player
{
    public class HumanPlayer : User
    {
        private PlayerInputHandler inputHandler;

        public HumanPlayer()
        {
            inputHandler = new(this, ennemyFieldOffset);
        }

        public override void MakeMove()
        {
            DrawPersonnalField();
            DrawEnnemyField();

            bool userHitEnnemy = true;

            while (userHitEnnemy)
            {
                inputHandler.TryToProcessInputOrHitEnnemy(out userHitEnnemy);

                if (userHitEnnemy)
                    ennemyField.DrawMarkedCells(ennemyFieldOffset);
            }
        }


        public override void DrawEnnemyField()
        {
            base.DrawEnnemyField();
            inputHandler.cursor.UpdatePositionInConsole();
        }
    }
}
