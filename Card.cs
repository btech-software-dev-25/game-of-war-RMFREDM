namespace GameOfWar
{
    public class Card
    {

        // Create a string property Suit with a private setter
        private string _suit;
        public string Suit {
            get => _suit;
            private set => _suit = value;
        }

        // Create an int property Rank with a private setter - values should range from 0 for a face value of 2 to 12 for an Ace
        private int _rank;
        public int Rank {
            get => _rank;
            private set {
                // ensure that the set value is between 0 and 12
                if (value >= 0 && value <= 12) {
                    _rank = value;
                }
            }
        }

        // Create a public constructor that takes suit and rank as arguments and assigns them to Suit and Rank
        public Card(string suit, int rank) {
            this.Suit = suit;
            this.Rank = rank;
        }

        // Overload the > operator to compare two cards by rank
        public static bool operator > (Card left, Card right) {
            return left.Rank > right.Rank;
        }

        // Overload the < operator to compare two cards by rank
        public static bool operator < (Card left, Card right) {
            return left.Rank < right.Rank;
        }


        // Create a public string method RankString that returns a string representation of this card's rank, 2-10 and Jack, Queen, King, Ace
        public string RankString() {
            switch (this.Rank) {
                case 0:
                    return "2";
                case 1:
                    return "3";
                case 2:
                    return "4";
                case 3:
                    return "5";
                case 4:
                    return "6";
                case 5:
                    return "7";
                case 6:
                    return "8";
                case 7:
                    return "9";
                case 8:
                    return "10";
                case 9:
                    return "Jack";
                case 10:
                    return "Queen";
                case 11:
                    return "King";
                case 12:
                    return "Ace";
            }
        }
    }
}