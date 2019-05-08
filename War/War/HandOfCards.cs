using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class HandOfCards
    {
        const int HAND_SIZE = 5;
        public PlayingCard[] gameHand1 = new PlayingCard[HAND_SIZE];


        public HandOfCards(int handSize, DeckOfCards gameDeck)
        {
            for (int i = 0; i < handSize; i++)
            {
                PlayingCard pc = gameDeck.dealCard();
                gameHand1[i] = pc;

            }

            showHand();

        }


        public void showHand()
        {
            Console.WriteLine("\n-----Showing Hand-----");
            foreach (PlayingCard pc in gameHand1)
            {

                Console.WriteLine("{0} of {1}\n", pc.strCardValue, pc.strSuitValue);
            }
        }
    }
}