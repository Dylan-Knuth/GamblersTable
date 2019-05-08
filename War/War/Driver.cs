using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class Driver_War
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n-------WELCOME TO WAR GAME-----------");

            Console.WriteLine("Enter Username: ");
            string name = Console.ReadLine();

            Player p1 = new Player(name);
            Console.Write($"\nName: {p1.name} Wins: {p1.wins} Losses: {p1.losses} Balance: {p1.balance}\n");

            DeckOfCards gameDeck = new DeckOfCards();

            Boolean keepPlaying = true;

            int handcount = 0;

            do
            {
                HandOfCards gameHand = new HandOfCards(5, gameDeck);
                handcount++;

                Boolean didwin = getCardsFromHand(gameHand);

                if (didwin == true)
                {
                    p1.wins = p1.wins + 1;
                    p1.balance = p1.balance + 10;
                }
                else
                {
                    p1.losses = p1.losses + 1;
                    p1.balance = p1.balance - 10;
                }

                // Update the players info after the battle

                updatePlayerFile(p1.name, p1.wins, p1.losses, p1.balance);

                Console.WriteLine("Updated:\nName: {0} Wins: {1} Losses: {2} Balance: {3}\n", p1.name, p1.wins, p1.losses, p1.balance);


                // Once theres 10 hands you need to create a new shuffled deck

                if (handcount == 10)
                {
                    gameDeck = new DeckOfCards();
                    gameDeck.shuffleDeck();
                    handcount = 0;
                }

                Console.WriteLine("-------Do you want to keep playing? [Y/N] ");
                String answer = Console.ReadLine();

                // if player answers no then stop the game

                if (answer == "N" || answer == "n")
                {
                    keepPlaying = false;
                }

            } while (keepPlaying == true && p1.balance > 0);

            // When the players balance = 0 end the game

            if (p1.balance <= 0)
            {
                Console.WriteLine("You are broke. YOU LOSE :((((((");
            }
        }

        public static Boolean getCardsFromHand(HandOfCards gameHand)
        {
            Random rnd = new Random();
            int playerNumber = rnd.Next(0, 4);
            int cpuNumber = rnd.Next(0, 4);

            do
            {
                cpuNumber = rnd.Next(0, 4);
            } while (cpuNumber == playerNumber);

            PlayingCard myCard = gameHand.gameHand1[playerNumber];
            PlayingCard cpuCard = gameHand.gameHand1[cpuNumber];

            Console.WriteLine("---------------------------------");
            Console.WriteLine("You drew a {0} of {1}\n", myCard.strCardValue, myCard.strSuitValue);
            Console.WriteLine("CPU drew a {0} of {1}\n", cpuCard.strCardValue, cpuCard.strSuitValue);

            Boolean didWin = battle(myCard, cpuCard);

            return didWin;


        }


        public static Boolean battle(PlayingCard p1, PlayingCard cpu)
        {
            Boolean win = false;
            int plValue = p1.cardValue;
            int cpuValue = cpu.cardValue;

            int plSuit = p1.suitValue;
            int cpuSuit = cpu.suitValue;


            if (plValue < cpuValue)
            {
                win = false;
            }

            else if (plValue > cpuValue)
            {
                win = true;
            }

            else
            {
                Console.WriteLine("WAR!!!!!!!!!\n");
                if (plSuit < cpuSuit)
                {
                    win = false;
                }

                else if (plSuit > cpuSuit)
                {
                    win = true;
                }
            }

            if (win == true)
            {
                Console.WriteLine("You Win!!!\n");
            }
            if (win == false)
                Console.WriteLine("You lose :((((\n");
            return win;
        }


        public static void updatePlayerFile(string name, int wins, int losses, int balance)
        {
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"../../player.txt");

            string[] playerData = File.ReadAllLines(path);

            foreach (String s in playerData)
            {
                var playerInfo = $"{name},{wins},{losses},{balance}";
                File.WriteAllText(path, playerInfo);
            }
        }

    }

}