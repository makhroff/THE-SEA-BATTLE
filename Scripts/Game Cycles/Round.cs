using Sea_battle.Users;
using Sea_battle.Other;

namespace Sea_battle.GameCycles
{
    public enum GamePhase
    {
        ShipsArrange,
        BattleProcess
    }
    public enum RoundWinner
    {
        User1,
        User2
    }

    public class Round
    {   
        private User currentUser;
        private User user1;
        private User user2;

        private bool gameIsRunning = true;

        private int shipsToArrange = 10;

        public Round(UserType userType1, UserType userType2)
        {
            user1 = userType1.GetNewUser();
            user2 = userType2.GetNewUser();

            currentUser = user1;
        }

        public void PlayGameAndReturnWinner(out RoundWinner winner)
        {
            user1.Setup("KIKRIL", user2.field);
            user2.Setup("BUBLIK", user1.field);

            user1.ArrangeShips(shipsToArrange);
            user2.ArrangeShips(shipsToArrange);

            while (gameIsRunning)
            {
                //if (currentUser.GetType() == typeof(HumanPlayer))
                WaitToUserToSwitch();

                Console.Clear();

                currentUser.MakeMove();

                if(HadSomebodyWon())
                    gameIsRunning = false;

                SwitchCurrentUser();
            }

            winner = (currentUser.name == user1.name) ? RoundWinner.User1 : RoundWinner.User2;
        }

        private bool HadSomebodyWon() 
            => currentUser.shipsLeft == 0;

        private void WaitToUserToSwitch()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine($"WAITING FOR {currentUser.name}");
            Console.WriteLine($"Press any button...");
            Console.ReadKey();
        }

        private void SwitchCurrentUser()
            => currentUser = (currentUser == user1) ? user2 : user1;
    }
}
