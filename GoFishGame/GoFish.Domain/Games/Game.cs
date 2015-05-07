using GoFish.Domain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class Game
    {
        private CardDeck _deck;

        public GameId Id { get; private set; }
        public Dictionary<PlayerId, List<Card>> Players { get; private set; }
        public List<Card> Stock { get; private set; }

        public Game(GameId id)
        {
            if (id == null)
                throw new InvalidOperationException("Game id is required.");

            _deck = new CardDeck();

            Id = id;
            Players = new Dictionary<PlayerId, List<Card>>();
            Stock = new List<Card>();
        }

        public void StartNewGame(List<PlayerId> players)
        {
            if (players.Count < 2 || players.Count > 5)
                throw new InvalidOperationException("New game requires two to five players.");

            AddPlayersToGame(players);

            DealGame();
        }

        private void AddPlayersToGame(List<PlayerId> players)
        {
            foreach (var player in players)
                Players.Add(player, new List<Card>());
        }

        private void DealGame()
        {
            if (Players.Count < 4)
                DealCards(7);
            else
                DealCards(5);
        }

        private void DealCards(int numberOfCardsPerPlayer)
        {
            var cards = _deck.GetShuffledCards();

            for (var i = 0; i < numberOfCardsPerPlayer; i++)
            {
                foreach (var player in Players)
                {
                    player.Value.Add(cards[0]);
                    cards.RemoveAt(0);
                }
            }

            Stock = cards;
        }
    }
}
