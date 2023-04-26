using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    public class Game
    {
        private UserType firstUserType;
        private UserType secondUserType;

        private int user1Wins = 0;
        private int user2Wins = 0;

        private static int RoundsNeededToWin = 3;

        public Game()
        {
            firstUserType = GetUserType("fisrt");
            secondUserType = GetUserType("second");
        }

        public void StartMatch()
        {
            bool isThereAWinner = false;

            while (!isThereAWinner)
            {
                Console.Clear();

                Round round = new(firstUserType, secondUserType);
                round.StartGameLoop(out RoundWinner roundWinner);

                isThereAWinner = ProcessRoundWinner(roundWinner);
            }
        }

        private bool ProcessRoundWinner(RoundWinner roundWinner)
        {
            if(roundWinner == RoundWinner.User1)
                user1Wins++;
            if(roundWinner == RoundWinner.User2)
                user2Wins++;

            return (user1Wins == RoundsNeededToWin || user2Wins == RoundsNeededToWin);
        }

        private UserType GetUserType(string index)
        {
            Console.Clear();

            Console.WriteLine($"Write 1 if the {index} user is a player, write 2 if the {index} user is a BOT!");
            string? output = Console.ReadLine();

            UserType userType = output switch
            {
                "1" => UserType.HumanPlayer,
                "2" => UserType.Bot,
                _ => GetUserType(index)
            };

            return userType;
        }
    }
}
