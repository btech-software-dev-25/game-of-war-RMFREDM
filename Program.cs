using GameOfWar;

// Create an instance of the GameState class
// Shuffle CardDeck within your instance
// Deal 26 cards each from CardDeck to your instance's PlayerDeck and ComputerDeck
GameState state = new GameState();
// gameState.CardDeck.Shuffle();
state.PlayerDeck.PushCards(state.CardDeck.Deal(26));
state.ComputerDeck.PushCards(state.CardDeck.Deal(26));

// Create a function with the signature: static bool PlayCards(GameState state, int playerCardIndex)
// The function should:
//     Pull the card at playerCardIndex from state.PlayerDeck
//     Pull the card at index 0 from state.ComputerDeck
//     Compare the two cards
//         If the player card is higher, the player gets both cards along with any in state.TableDeck
//         If the computer card is higher, the computer gets both cards along with any in state.TableDeck
//         If the player and computer cards are the same, both cards go into state.TableDeck
//     Check whether either state.PlayerDeck or state.ComputerDeck are empty
//         If the computer deck is empty, the player wins and state.Winner should be set to "Computer"
//         If the player deck is empty, the computer wins and state.Winner should be set to "Player"
//     return true
static bool PlayCards(GameState state, int playerCardIndex) {
    // pull cards from the player and computer decks
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);

    // compare the cards and perform the appropriate action
    if (playerCard > computerCard) {
        state.PlayerDeck.PushCard(computerCard);
        state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
    } else if (playerCard < computerCard) {
        state.ComputerDeck.PushCard(playerCard);
        state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
    } else {
        state.TableDeck.PushCards([playerCard, computerCard]);
    }

    // check if there is a winner
    if (state.ComputerDeck.Count == 0) {
        state.Winner = "Player";
    } else if (state.PlayerDeck.Count == 0) {
        state.Winner = "Computer";
    }

    return true;
}

// Call Lib.RunGame(), passing two parameters: the state object you instantiated above and the name of your PlayCards function
Lib.RunGame(state, PlayCards);