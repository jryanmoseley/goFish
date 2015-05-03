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

            Id = id;
            _deck = new CardDeck();
            Stock = new List<Card>();
        }

        public void StartNewGame(List<PlayerId> Players)
        {

        }
    }
}
