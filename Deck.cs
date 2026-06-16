namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };


        // Create a public int property Count that returns the Count value from the private collection _cards
        public int Count {
            get => _cards.Count;
        }

        // Create a private field _cards that is a List<Card>
        private List<Card> _cards;

        // Create a public constructor that takes two parameter: a List<card> called cards and a boolean value called isEmptyDeck
        // If cards is not null and has elements in it, assign it to _cards and be done
        // If cards is null or empty:
        //     _cards should be initialized as an empty List<Card>
        //     InitializeDeck() should be called if and only if isEmptyDeck is false
        public Deck(List<Card> cards = null, bool isEmptyDeck = true) {
            // check if cards has values in it and initialize the deck
            if (cards != null && cards.Count > 0) {
                this._cards = cards;
            } else {
                this._cards = [];
                if (!isEmptyDeck) {
                    this.InitializeDeck();
                }
            }
        }


        // Create a private void method called InitializeDeck() which does the following:
        // Use RankNames and Suits in nested loops to generate all 52 combinations of rank and suit and add them to _cards
        private void InitializeDeck() {
            // loop through every suit
            foreach (string suit in Deck.Suits) {
                // loop through every rank
                foreach (string rankString in Deck.RankNames) {
                    // add a new card of the appropriate suit and rank
                    int rankInt;
                    if (int.TryParse(rankString, out rankInt)) {
                        this.PushCard(new Card(suit, rankInt - 2));
                    } else if (rankString == "Jack") {
                        this.PushCard(new Card(suit, 9));
                    } else if (rankString == "Queen") {
                        this.PushCard(new Card(suit, 10));
                    } else if (rankString == "King") {
                        this.PushCard(new Card(suit, 11));
                    } else if (rankString == "Ace") {
                        this.PushCard(new Card(suit, 12));
                    }
                }
            }
        }

        // Create a public void method called Shuffle() which shuffles (rearranges) the cards in _cards


        // Create a public method CardAtIndex which takes an int parameter for the index of a card and
        // returns the card at the index specified, or throws IndexOutOfRangeException if index is too large or too small
        public Card CardAtIndex(int index) {
            return this._cards[index];
        }

        // Create a public method PullCardAtIndex which does exactly the same thing as CardAtIndex
        // with the additional feature that it _removes_ the card from the deck
        public Card PullCardAtIndex(int index) {
            Card pulledCard = _cards[index];
            this._cards.RemoveAt(index);
            return pulledCard;
        }

        // Create a public method PullAllCards that returns a list of all of the cards in the deck
        // and removes them all from the deck, leaving it empty
        public List<Card> PullAllCards() {
            // iterate through every card, pull them, and add them to a list of pulled cards
            List<Card> pulledCards = [];
            for (int index = 0; index < this.Count; index++) {
                pulledCards.Add(this.PullCardAtIndex(index));
            }
            return pulledCards;
        }


        // Create a public method PushCard that accepts a Card as a parameter and adds it to _cards
        public void PushCard(Card card) {
            this._cards.Add(card);
        }

        // Create a public method PushCards that accepts a List<Card> as a parameter and adds the list to _cards
        // Be sure to use AddRange and not Add
        public void PushCards(List<Card> cards) {
            this._cards.AddRange(cards);
        }

        // Create a public method Deal that accepts an integer representing the number of cards to deal
        // and then removes that many cards from the deck, returning them as a List<Card>
        // Be sure to check the size of _cards against the number of cards requested so you don't go out
        // of bounds
        public List<Card> Deal(int cardsDealt) {
            // ensure cards are not dealt beyond to contents of _cards
            if (cardsDealt > this.Count) {
                return this.PullAllCards();
            }

            // pull cards from the top of the deck a number of times equal to cardsDealt, then return the list of dealt cards
            List<Card> cards = [];
            for (int i = 0; i < cardsDealt; i++) {
                cards.Add(this.PullCardAtIndex(0));
            }
            return cards;
        }
    }
}
