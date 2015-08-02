using GoFish.Domain.Common;
using GoFish.Domain.Games.Events;
using GoFish.Domain.Games.States;
using GoFish.Domain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class Game : Entity
    {
        private CardDeck _cardDeck;

        public Game(GameId gameId, List<PlayerId> players, CardDeck cardDeck)
        {
            if (gameId == null)
                throw new InvalidOperationException("Game id is required.");

            _cardDeck = cardDeck;

            GameId = gameId;
            Players = new List<GamePlayer>();
            Stock = new List<Card>();

            StartNewGame(players);
        }

        public GameId GameId { get; private set; }
        public List<GamePlayer> Players { get; private set; }
        public List<Card> Stock { get; private set; }
        public List<PlayerId> TurnOrder { get; private set; }
        public PlayerId PlayerTurn { get; private set; }
        public GameState State { get; private set; }

        public void PlayerRequestCard(CardRequest request)
        {
            ValidateRequest(request);

            State = new CardRequestedState(request);
            PlayerTurn = request.Requestee;
            Events.Add(new CardRequested(GameId, request));
        }

        private void ValidateRequest(CardRequest request)
        {
            if (!PlayerTurn.Equals(request.Requestor))
                throw new InvalidOperationException("It is not your turn.");

            if (RequestorDoesNotHoldRequestedCard(request))
                throw new InvalidOperationException("You can only request cards that you have.");

            if (request.Requestee.Equals(request.Requestor))
                throw new InvalidOperationException("You cannot request cards from yourself.");

            if (!Players.Any(x => x.PlayerId.Equals(request.Requestee)))
                throw new InvalidOperationException("Requestee is not a player in this game.");
        }

        private void StartNewGame(List<PlayerId> players)
        {
            if (players.Count < 2 || players.Count > 5)
                throw new InvalidOperationException("New game requires two to five players.");

            AddPlayersToGame(players);

            DealGame();

            EstablishTurns(players);
        }

        private void AddPlayersToGame(List<PlayerId> players)
        {
            foreach (var player in players)
                Players.Add(new GamePlayer(player));
        }

        private void DealGame()
        {
            if (Players.Count < 4)
                DealCards(7);
            else
                DealCards(5);
        }

        private void EstablishTurns(List<PlayerId> players)
        {
            TurnOrder = players;
            PlayerTurn = players[0];
        }

        private void DealCards(int numberOfCardsPerPlayer)
        {
            var cards = _cardDeck.GetShuffledCards();

            for (var i = 0; i < numberOfCardsPerPlayer; i++)
            {
                foreach (var player in Players)
                {
                    player.DealCard(cards[0]);
                    cards.RemoveAt(0);
                }
            }

            Stock = cards;
        }

        private bool RequestorDoesNotHoldRequestedCard(CardRequest request)
        {
            return !Players.Single(x => x.PlayerId.Equals(request.Requestor))
                .Cards.Any(x => x.Rank.Equals(request.CardRank));
        }
    }
}
