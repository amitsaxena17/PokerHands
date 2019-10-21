using System;

namespace PokerHandsAPI
{
    public class PokerHandsResults
    {
        public DateTime Date { get; set; }        
        public string Winner { get; set; }

        public string Player1CardList { get; set; }

        public string Player2CardList { get; set; }

        public string Player1Hand { get; set; }

        public string Player2Hand { get; set; }
    }
}
