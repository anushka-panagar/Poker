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
               // write a function which takes 2 Hands as arguments and returns strongest Hand
        public static Hand GetStrongHand(Hand hand1, Hand hand2)
        {
            // Get the weights
            if (hand1.HandType == hand2.HandType)
            {
                // Write a method which takes 2 Hands of Flush type and perform tie breaker rules and return Stronger Hand
              return CompareHands(hand1,hand2);

            }

            return hand1.HandType > hand2.HandType ? hand1 : hand2;
            
        }

        public static Hand CompareHands(Hand hand1, Hand hand2)
        {
            int[] cardWeight1 = new int[5];
            int[] cardWeight2 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                cardWeight1[i] = hand1.cards[i].Value;
                cardWeight2[i] = hand2.cards[i].Value;
            }
            Array.Sort(cardWeight1);
            Array.Sort(cardWeight2);
            Array.Reverse(cardWeight1);
            Array.Reverse(cardWeight2);

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
