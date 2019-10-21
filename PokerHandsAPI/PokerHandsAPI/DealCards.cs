using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsAPI
{
    class DealCards : DeckOfCards
    {
        private Card[] player1Hand;
        private Card[] player2Hand;
        private Card[] sortedPlayerHand;
        private Card[] sortedplayer2Hand;

        public DealCards()
        {
            player1Hand = new Card[5];
            sortedPlayerHand = new Card[5];
            player2Hand = new Card[5];
            sortedplayer2Hand = new Card[5];
        }

        
        public List<PokerHandsResults> Deal(string p1, string p2)
        {
            //create the deck of cards and shuffle them
            setUpDeck();
            getHand();
            sortCards();            
            return evaluateHands(p1,p2);
        }

        public void getHand()
        {
            //5 cards for the player
            for (int i = 0; i < 5; i++)
                player1Hand[i] = getDeck[i];

            //5 cards for the computer
            for (int i = 5; i < 10; i++)
                player2Hand[i -5] = getDeck[i];
        }

        public void sortCards()
        {
            var queryPlayer = from hand in player1Hand
                              orderby hand.MyValue
                              select hand;

            var queryComputer = from hand in player2Hand
                                orderby hand.MyValue
                                select hand;

            var index = 0;
            foreach(var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            index = 0;
            foreach (var element in queryComputer.ToList())
            {
                sortedplayer2Hand[index] = element;
                index++;
            }
        }

       

        public List<PokerHandsResults> evaluateHands(string p1, string p2)
        {
            List<PokerHandsResults> results = new List<PokerHandsResults>();
            PokerHandsResults pokerHandsResults = new PokerHandsResults();
            pokerHandsResults.Date = DateTime.Now;
            //create player's computer's evaluation objects (passing SORTED hand to constructor)
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);
            HandEvaluator player2HandEvaluator = new HandEvaluator(sortedplayer2Hand);

            //get the player;s and computer's hand
            Hand playerHand = playerHandEvaluator.EvaluateHand();
            Hand player2Hand = player2HandEvaluator.EvaluateHand();
            

            //evaluate hands
            if (playerHand > player2Hand)
            {
                pokerHandsResults.Winner= p1 + " WINS!";
            }
            else if (playerHand < player2Hand)
            {
                pokerHandsResults.Winner = p2 + " WINS!";
            }
            else //if the hands are the same, evaluate the values
            {
                //first evaluate who has higher value of poker hand
                if (playerHandEvaluator.HandValues.Total > player2HandEvaluator.HandValues.Total)
                    pokerHandsResults.Winner = p1 + " WINS!";
                else if (playerHandEvaluator.HandValues.Total < player2HandEvaluator.HandValues.Total)
                    pokerHandsResults.Winner = p2 + " WINS!";
                //if both hanve the same poker hand (for example, both have a pair of queens), 
                //than the player with the next higher card wins
                else if (playerHandEvaluator.HandValues.HighCard > player2HandEvaluator.HandValues.HighCard)
                    pokerHandsResults.Winner = p1 + " WINS!";
                else if (playerHandEvaluator.HandValues.HighCard < player2HandEvaluator.HandValues.HighCard)
                    pokerHandsResults.Winner = p2 + " WINS!";
                else
                    pokerHandsResults.Winner = "DRAW, no one wins!";
            }



            pokerHandsResults.Player1Hand = string.Join(",", playerHand);
            pokerHandsResults.Player2Hand = string.Join(",", player2Hand);


            

            foreach (Card x in sortedPlayerHand.ToList())
            {
                pokerHandsResults.Player1CardList += x.MySuit.ToString() + "-" + x.MyValue  +  " ^  ";
            }

            foreach (Card x in sortedplayer2Hand.ToList())
            {
                pokerHandsResults.Player2CardList += x.MySuit.ToString() + "-" + x.MyValue + " ^  ";
            }

            results.Add(pokerHandsResults);
            
            return results;
            
        }
    }
}
