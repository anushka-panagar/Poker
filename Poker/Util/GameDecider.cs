using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Entity;
using Poker.Enum;

namespace Poker.Util
{
    class GameDecider
    {
       //Function which takes 2 Hands as arguments and returns strongest Hand
        public static Hand GetStrongHand(Hand hand1, Hand hand2)
        {
            // Get the weights
            if (hand1.HandType == hand2.HandType)
            {
             // Method which takes 2 Hands of Flush type and perform tie breaker rules and return Stronger Hand
              return CompareHands(hand1,hand2);
            }
            return hand1.HandType > hand2.HandType ? hand1 : hand2;
        }

        public static Hand CompareHands(Hand hand1, Hand hand2)
        {
            // initializing the Array with 5 cards as an array length
            int[] cardWeight1 = new int[5];
            int[] cardWeight2 = new int[5];

            // Get the Values of both the cards
            for (int i = 0; i < 5; i++)
            {
                cardWeight1[i] = hand1.cards[i].Value;
                cardWeight2[i] = hand2.cards[i].Value;
            }
            // Sort the Array 
            Array.Sort(cardWeight1);
            Array.Sort(cardWeight2);
            // Reverse the array to get the highest number first
            Array.Reverse(cardWeight1);
            Array.Reverse(cardWeight2);

            // checking the highest number in the array
            for(int i = 0; i < cardWeight1.Length; i++)
            {
                // check if both values are same then go to next counter (i),
                if (cardWeight1[i] == cardWeight2[i])
                {
                    continue;
                }
                else if (cardWeight1[i] > cardWeight2[i])
                {
                    return hand1;
                }
                else { return hand2; }
     
            }
            return null;
        }
    }
}
