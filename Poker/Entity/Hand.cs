using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Enum;

namespace Poker.Entity
{
    class Hand
    {

        public Card[] cards = new Card[5];
        public HandType HandType { get; set; }
        
        public Player Player { get; set; }
        public Hand(Card[] cards)
        {
            this.cards = cards;
            this.SetHandType();
        }

        public override string ToString()
        {
            string str = "";
            for(int i = 0; i < cards.Length ; i++ )
            {
               str = str + cards[i] +", ";
            }

            return str;
        }

        private void SetHandType()
        {
            this.HandType =  this.IsFlush() ?  HandType.Flush : this.GetPairKind();
        }

        private Boolean IsFlush()
        {
            char suit = cards[0].Suit;
            for(int i = 1; i< cards.Length; i++)
            {
                if(cards[i].Suit != suit)
                {
                    return false;
                }
            }
            return true;
        }

        private HandType GetPairKind()
        {

            // create an empty array 
            int[] tempArray = new int[5];
         
            // push the card values into array
            for (int i = 0; i < cards.Length; i++)
            {
                tempArray[i] = cards[i].Value;
            }
            int distinctValues = tempArray.Distinct().ToArray().Length;
            if (tempArray.Length - distinctValues == 2)
            {
                return HandType.ThreeOfAKind;
            }
            else if(tempArray.Length - distinctValues == 1)
            {
                return HandType.OnePair;
            }
            return HandType.NoPair;

            // [5,4,5,A,5] ->5 => [5,4,A]-> 3 === 5-3 =2 (3 of a kind)
            // [5,4,1,A,5] ->5 => [5,4,A,1]-> 4 === 5-4 =1 (1 pair)
            // [5,4,1,A,6] ->5 => [5,4,A,1,6]->5 === 5-5 =0 (HIGH ONE)

        }
    }
}
