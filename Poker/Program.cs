using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Entity;
using Poker.Enum;
using System.Collections;
using Poker.Util;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Create a New List of Players
            List<Player> players = new List<Player>();
            // checker variable for the adding a New Player
            bool isNextPlayerExist;
            // Do while Loop which loops untill the Next player Exists
            do
            {
                Console.WriteLine("Please Enter Player Name");
                String playerName = Console.ReadLine();
                Player player = new Player(playerName);
                Card[] cards = new Card[5]; // take array of size 5
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Enter Your Card No " + (i + 1));
                    String card = Console.ReadLine();
                    cards[i] = new Card(card);
                }
                // Assign the Hand of the player
                player.Hand = new Hand(cards);
                player.Hand.Player = player;
                players.Add(player);
                Console.WriteLine("Do you want to add another player? Enter Y/N");
                String input = Console.ReadLine();
                isNextPlayerExist = input.Equals("Y");
            } while (isNextPlayerExist);

            // highestHand Var set to null checks for the Hands of all the players and retunrs the highest hand
            Hand highestHand = null;
            foreach (Player p in players)
            {
                if (highestHand == null)
                {
                    highestHand = p.Hand;
                    continue;
                }
                else
                {
                    highestHand = GameDecider.GetStrongHand(highestHand, p.Hand);
                }
            }
            Console.WriteLine(highestHand.Player.Name + " Wins with " + "Hand " + highestHand);
            Console.ReadKey();
        }
    }
}
