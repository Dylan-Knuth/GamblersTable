using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Driver_Blackjack
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n-------Welcome To BlackJack-----------");

            //Console.WriteLine("Enter Username: ");
            //string name = Console.ReadLine();

            //Player p1 = new Player(name);
            //Console.Write($"\nName: {p1.name} Wins: {p1.wins} Losses: {p1.losses} Balance: {p1.balance}\n");

            DeckOfCards gameDeck = new DeckOfCards();

            HandOfCards cpuHand = new HandOfCards(gameDeck);

            Console.WriteLine("\n*****************Dealers*******************\n\n");
            cpuHand.showDealerHand();
            Console.WriteLine("\n*******************************************\n");
            int dealerCount = cpuHand.handValue();

            HandOfCards playerHand = new HandOfCards(gameDeck);
            Console.WriteLine("\n**********YOURS**********\n");
            playerHand.showHand();
            int playerHandValue = playerHand.handValue();
            Console.WriteLine($"\nYour Hand Value: {playerHandValue}\n******************************\n\n");

            // player option : hit, stay, double
            Console.WriteLine($"\nHIT(h) STAY(s) DOUBLE(d)??");
            string option = Console.ReadLine();
            string keepGoing ="y";

            do
            {
                if (option == "h")
                {
                    PlayingCard pc = gameDeck.dealCard();
                    playerHand.Add(pc);


                    Console.WriteLine("\n************************Dealers************************\n\n");
                    cpuHand.showDealerHand();
                    dealerCount = cpuHand.handValue();
                    Console.WriteLine($"\nDealer Hand Value: {dealerCount}\n************************************************************\n\n");
                    dealerCount = cpuHand.handValue();


                    Console.WriteLine("\n************************YOURS************************\n");
                    playerHand.showHand();
                    playerHandValue = playerHand.handValue();
                    Console.WriteLine($"\nYour Hand Value: {playerHandValue}\n************************************************************\n\n");
                    Console.WriteLine($"\nHIT(h) STAY(s)\n");
                }

                else if (option == "s")
                {
                    PlayingCard pc = gameDeck.dealCard();

                    Console.WriteLine("\n************Dealers************************\n");
                    cpuHand.showHand();
                    dealerCount = cpuHand.handValue();
                    Console.WriteLine($"\nDealer Hand Value: {dealerCount}\n************************************************************\n\n");



                    Console.WriteLine("\n************YOURS************************\n");
                    playerHand.showHand();
                    playerHandValue = playerHand.handValue();
                    Console.WriteLine($"\nYour Hand Value: {playerHandValue}\n************************************************************\n\n");



                    while (playerHandValue < 22 && dealerCount < 17)
                    {
                        pc = gameDeck.dealCard();
                        cpuHand.Add(pc);
                        Console.WriteLine("\n************************Dealers************************\n");
                        cpuHand.showHand();
                        dealerCount = cpuHand.handValue();
                        Console.WriteLine($"\nDealer Hand Value: {dealerCount}\n************************************************************\n\n");

                    }
                    Console.WriteLine($"\nHIT(h) STAY(s)\n");


                }
                //              double
                else if (option == "d")
                {
                    PlayingCard pc = gameDeck.dealCard();
                    playerHand.Add(pc);
                    Console.WriteLine("\n************Dealers************************\n");
                    cpuHand.showHand();
                    dealerCount = cpuHand.handValue();
                    Console.WriteLine($"\nDealer Hand Value: {dealerCount}\n************************************************************\n\n");

                    Console.WriteLine("\n************YOURS************************\n");
                    playerHand.showHand();
                    playerHandValue = playerHand.handValue();
                    Console.WriteLine($"\nYour Hand Value: {playerHandValue}\n************************************************************\n\n");

                                       
                    while (playerHandValue < 22 && dealerCount < 17)
                    {
                        pc = gameDeck.dealCard();
                        cpuHand.Add(pc);
                        Console.WriteLine("\n************************Dealers************************\n");
                        cpuHand.showHand();
                        dealerCount = cpuHand.handValue();
                        Console.WriteLine($"\nDealer Hand Value: {dealerCount}\n************************************************************\n\n");

                    }

                    dealerCount = cpuHand.handValue();
                    playerHandValue = playerHand.handValue();

                }

                winner(playerHandValue, dealerCount);
                Console.WriteLine($"\nKeep going(y)? or quit(q)?");
                keepGoing = Console.ReadLine();

                if (keepGoing == "y")
                {
                    cpuHand = new HandOfCards(gameDeck);

                    Console.WriteLine("\n************************Dealers************************\n\n");
                    cpuHand.showDealerHand();
                    Console.WriteLine("\n************************************************************\n\n");
                    dealerCount = cpuHand.handValue();

                    playerHand = new HandOfCards(gameDeck);
                    Console.WriteLine("\n************************YOURS************************\n");
                    playerHand.showHand();
                    playerHandValue = playerHand.handValue();
                    Console.WriteLine($"\nYour Hand Value: {playerHandValue}\n************************************************************\n\n");

                    // player option : hit, stay, double
                    Console.WriteLine($"\nHIT(h) STAY(s) DOUBLE(d)??");
                    option = Console.ReadLine();
                }
                //option = Console.ReadLine();
            } while (keepGoing == "y");
        }


        public static void winner(int playerHandValue, int dealerCount)
        {
            if (playerHandValue > 21)
            {
                Console.WriteLine("You Lose");
            }
            else if (dealerCount > 21)
            {
                Console.WriteLine("You Win");

            }
            else
            {
                if (playerHandValue > dealerCount)
                {
                    Console.WriteLine("You Win");

                }
                else
                    Console.WriteLine("You Lose");

            }

        }



    }
}