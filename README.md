# Poker
Poker game is developed with C# functions with input as the name and Combination Card Hands which reads the output as the Name of the Winner with that particular hand

Assumptions for the Poker Game
1. The Card Sequence and The Player Name are valid value ie there is no garbage values in the input
2. The Suit type is between these 4 - Suit - Heart, Diamond, Spade and Club
3. The Number of the Card Types are between 2-Ace = 2,3,4,5,6,7,8,9,10,J,Q,K,Ace
4. Poker is designed for the Multiple Players - you can add and compare the weights of the Hand of the multiplee players
5. Every Player has a set of 5 cards - not more or less ; Array Size is predefined as 5
6. Making sure the Player holding Flush Wins ; if 2 or more players have Flush the winner is the one with the highest card number

Algorithmic Steps for Poker :

// Stage 1
1. Get User name as String from consone // Exmaple; Joe
2. Get Hand details as String // 8S, 8H, 8C, 6S, 7H
3. Parse hand details to get Hand object which contains List of Cards
4. Display Hand Object 


// Stage 2
5. Use GameRules Class to determine type of // Flush
6. Create method that evaluate tie break rule based on Hand type
7. Create helper method to comapare 2 types of cards. 
// takes hand1, hand2 as arg and return 1 if hand1 is strong, returns -1 if hand2 is strong or 0 if both hands are equal 
// If hands are equal use TieBreakerMethod to tie break


// Stage3 Find Winner
8. Loop Thorugh all uses
9. Find the highest hand and Print it
