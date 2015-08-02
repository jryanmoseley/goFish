using GoFish.Application.Games.Commands;
using GoFish.Domain.Games;
using GoFish.Domain.Players;
using System;
using System.Linq;

namespace GoFish.Application.Games
{
    public class GameApplicationService : IGameApplicationService
    {
        private readonly IGameRepository _gameRepository;

        public GameApplicationService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public string StartNewGame(StartNewGame command)
        {
            var gameId = new GameId(Guid.NewGuid().ToString());
            var players = command.PlayerIds.Select(p => new PlayerId(p)).ToList();

            var game = new Game(gameId, players, new CardDeck());
            _gameRepository.Save(game);

            return gameId.ToString();
        }

        public void RequestCard(RequestCard command)
        {
            var game = _gameRepository.Get(new GameId(command.GameId));

            var cardRequest = new CardRequest(
                new PlayerId(command.Requestor),
                new PlayerId(command.Requestee),
                CardRankExtensions.ToEnum(command.CardRank));

            game.PlayerRequestCard(cardRequest);

            _gameRepository.Save(game);
        }
    }
}
