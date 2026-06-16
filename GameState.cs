namespace GameOfWar
{
    public class GameState
    {
        // Create a public Deck property called CardDeck
        public Deck CardDeck {
            get;
            set;
        }

        // Create a public Deck property called PlayerDeck
        public Deck PlayerDeck {
            get;
            set;
        }

        // Create a public Deck property called ComputerDeck
        public Deck ComputerDeck {
            get;
            set;
        }

        // Create a public Deck property called TableDeck
        public Deck TableDeck {
            get;
            set;
        }

        // Create a public string property called Winner
        public string Winner {
            get;
            set;
        }

        // Create a public constructor that accepts no parameters. It should:
        //    Initialize Winner to be empty (not null)
        //    Initialize CardDeck to be a new, fresh deck of 52 cards
        //    Initialize PlayerDeck, ComputerDeck, and TableDeck to be empty Deck objects (no cards)
        public GameState() {
            this.Winner = "";
            this.CardDeck = new Deck([], false);
            this.PlayerDeck = new Deck();
            this.ComputerDeck = new Deck();
            this.TableDeck = new Deck();
        }
    }
}