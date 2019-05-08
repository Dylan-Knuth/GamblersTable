using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class DeckOfCards
    {
        const int NUMBER_OF_CARDS = 52*6;

        PlayingCard[] deck = new PlayingCard[NUMBER_OF_CARDS];

        int topOfDeck = 0;
        int ct = 0;

        public DeckOfCards()
        {
            for (int deckCT = 1; deckCT <= 6; deckCT++)
            {
                for (int suit = 1; suit <= 4; suit++)
                {
                    for (int val = 1; val <= 13; val++)
                    {
                        deck[ct++] = new PlayingCard(val, suit);
                    }

                }
            }

            //showDeck();
            shuffleDeck();
        }

        public PlayingCard dealCard()
        {
            PlayingCard topcard = deck[topOfDeck++];
            PlayingCard pc = topcard;
            return pc;
        }

        public void showDeck()
        {
            Console.WriteLine("\n-----Showing Deck-----");

            if (deck == null)
            {
                Console.WriteLine("Empty Deck");
            }

            foreach (PlayingCard pc in deck)
            {
                Console.Write("\nCard {0} of {1}\n", pc.strCardValue,
                    pc.strSuitValue);
            }
        }

        public void shuffleDeck()
        {
            // int currentCard = 0;

            Random ranNum = new Random();

            for (int i = 0; i < deck.Length; i++)
            {

                int second = ranNum.Next(NUMBER_OF_CARDS);
                PlayingCard temp = deck[i];
                deck[i] = deck[second];
                deck[second] = temp;

            }


        }
    }
}
