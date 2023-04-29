using Sea_battle.Users;
using Sea_battle.Other;
using Sea_battle.Users.Player;

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

        private PlayerProfile profile1;
        private PlayerProfile profile2;

        private bool isUser1AHuman;
        private bool isUser2AHuman;

        private bool gameIsRunning = true;

        private int shipsToArrange = 10;

        public Round(UserType userType1, UserType userType2, PlayerProfile profile1, PlayerProfile profile2)
        {
            user1 = userType1.GetNewUser();
            user2 = userType2.GetNewUser();

            isUser1AHuman = userType1 == UserType.HumanPlayer;
            isUser2AHuman = userType2 == UserType.HumanPlayer;

            this.profile1 = profile1;
            this.profile2 = profile2;

            currentUser = user1;
        }

        public void PlayGameAndReturnWinner(out RoundWinner winner)
        {
            SetUpUser(user1, isUser1AHuman, profile1);
            SetUpUser(user2, isUser2AHuman, profile2);

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

        private void SetUpUser(User user, bool isAHuman, PlayerProfile profile)
        {
            if (isAHuman)
                user1.Setup(user.field, profile);
            else
                user1.Setup(user.field);
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
