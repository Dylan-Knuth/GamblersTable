using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class HandOfCards
    {
        //  FOR BLACKJACK TESTING
        public List<PlayingCard> gameHand = new List<PlayingCard>();



        public HandOfCards(DeckOfCards gameDeck)
        //        public HandOfCards(int handSize, DeckOfCards gameDeck)
        {
            PlayingCard pc = gameDeck.dealCard();
            gameHand.Add(pc);
            pc = gameDeck.dealCard();
            gameHand.Add(pc);

            //for (int i = 0; i < handSize; i++)
            //{
            //    PlayingCard pc = gameDeck.dealCard();
            //    gameHand[i] = pc;

            //}

            //showHand();

            handValue();

        }
        internal void Add(PlayingCard pc)
        {
            gameHand.Add(pc);
        }

        public int handValue()
        {
            int handValue = 0;
            foreach (PlayingCard pc in gameHand)
            {
                if (pc.cardValue > 10)
                {
                    pc.cardValue = 10;
                }
                handValue = pc.cardValue + handValue;
            }
            return handValue;
        }
        public void showHand()
        {
            //Console.WriteLine("\n-----Showing Hand-----");
            foreach (PlayingCard pc in gameHand)
            {

                Console.WriteLine("{0} of {1}\n", pc.strCardValue, pc.strSuitValue);
            }
        }
        public void showDealerHand()
        {
            //Console.WriteLine("\n-----Showing Dealer Hand-----");
            foreach (PlayingCard pc in gameHand)
            {
                if (gameHand.First() == pc)
                {
                    Console.WriteLine("???????????????????????????????\n");
                }
                else
                {
                    Console.WriteLine("{0} of {1}\n", pc.strCardValue, pc.strSuitValue);
                }
            }
        }

    }
}