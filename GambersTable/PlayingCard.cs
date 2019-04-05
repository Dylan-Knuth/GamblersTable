using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambersTable
{
    public class PlayingCard
    {
        public int cardValue { get; set; }
        public int suitValue { get; set; }
        public string strCardValue { get; set; }
        public string strSuitValue { get; set; }

        public PlayingCard(int cardV, int suitV)
        {
            cardValue = cardV;
            this.suitValue = suitV;
            setStrCardValue();
            setStrSuitValue();
        }


        public void setStrCardValue()
        {             //Change this to a switch!!
            if (cardValue >= 2 && cardValue <= 10)
            {
                strCardValue = Convert.ToString(cardValue);
            }
            else if (cardValue == 1)
            {
                strCardValue = "Ace";
            }
            else if (cardValue == 11)
            {
                strCardValue = "Jack";
            }
            else if (cardValue == 12)
            {
                strCardValue = "Queen";
            }
            else if (cardValue == 13)
            {
                strCardValue = "King";
            }
            else
            {
                Console.Write("ERROR ON CARD VAULE: {0}", cardValue);
            }
        }


        public void setStrSuitValue()
        {
            if (suitValue == 4)
            {
                strSuitValue = "Spades";
            }
            else if (suitValue == 3)
            {
                strSuitValue = "Clubs";
            }
            else if (suitValue == 2)
            {
                strSuitValue = "Hearts";
            }
            else if (suitValue == 1)
            {
                strSuitValue = "Diamonds";
            }
            else
            {
                Console.WriteLine("ERROR ON SUIT VALUE: {0}", suitValue);
            }
        }
    }
}
