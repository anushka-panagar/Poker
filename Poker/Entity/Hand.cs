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
        // constructor which determines the Hand Type whether it is Flush, One Pair, Three of A Kind which indeed helps to determine the solution
        public Hand(Card[] cards)
        {
            this.cards = cards;
            this.SetHandType();
        }
        // Getting the Hands in a sequence entered by a Player in String
        public override string ToString()
        {
            string str = "";
            for(int i = 0; i < cards.Length ; i++ )
            {
               str = str + cards[i] +", ";
            }

            return str;
        }
        // Determining the HandType on the condition if it is Flush that Player with Handtype Flush is returned else check other subsets of the poker hands
        // @returns HandType for the sequence of Hands 
        private void SetHandType()
        {
            this.HandType =  this.IsFlush() ?  HandType.Flush : this.GetPairKind();
        }

        // Condition checking if the Hand is Flush or Not returns boolean value 
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

        // Checking if the HandType is not Flush ; what other Hand Types exists 
        // returns the HandType other than Flush
        private HandType GetPairKind()
        {
            // create an empty array 
            int[] tempArray = new int[5];
         
            // push the card values into array
            for (int i = 0; i < cards.Length; i++)
            {
                tempArray[i] = cards[i].Value;
            }
            // checking the arraylength with distinct values
            // [5,4,5,A,5] ->5 => [5,4,A]-> 3 === 5-3 =2 (3 of a kind)
            int distinctValues = tempArray.Distinct().ToArray().Length;
            if (tempArray.Length - distinctValues == 2)
            {
                return HandType.ThreeOfAKind;
            }
            // [5,4,1,A,5] ->5 => [5,4,A,1]-> 4 === 5-4 =1 (1 pair)
            else if (tempArray.Length - distinctValues == 1)
            {
                return HandType.OnePair;
            }
            // [5,4,1,A,6] ->5 => [5,4,A,1,6]->5 === 5-5 =0 (HIGH ONE)
            return HandType.NoPair;
        }
    }
}
