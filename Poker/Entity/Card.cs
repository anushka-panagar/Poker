using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Enum;

namespace Poker.Entity
{
    public class Card
    {
        public string DisplayName { get; set; }
        public int Value { get; set; }
        public Char Suit { get; set; }
        // Constructor for the card which displays the name and gets the card value / weight for that particular card
        public Card(string DisplayName)
        {
            this.DisplayName = DisplayName;
            this.getCardValue();
        }

        // Gets the card value / weight for the card 
        private void getCardValue()
        {
            Char tempSuitChar;
            String ValueChar = this.DisplayName.Substring(0, this.DisplayName.Length - 1);
            bool result = Char.TryParse(this.DisplayName.Substring(this.DisplayName.Length - 1, 1), out tempSuitChar);
            this.Suit = tempSuitChar;
            this.Value = this.GetCardValueWeight(ValueChar);
        }

        // Method Override of ToString() for displaying the name
        public override string ToString()
        {
            return this.DisplayName;
        }       
               
        // Switch case for Getting the Card Weight based on the Card Value parsed and Entered by the user
        // Solution can be optimized by Polymorphism and declaring the Card Weights in Dictionary if there are other switch cases added following the project, but for Poker this does 
        // does not exceed after Ace 
        private int GetCardValueWeight(string cardValue)
        {
            switch (cardValue.ToUpper())
            {
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return 0;
            }
        }

       
        
    }
}
