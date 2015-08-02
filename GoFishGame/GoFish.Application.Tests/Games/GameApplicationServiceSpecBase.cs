using GoFish.Application.Games;
using GoFish.Domain.Games;
using GoFish.Domain.Players;
using GoFish.Infrastructure.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GoFish.Application.Tests.Games
{
    public class GameApplicationServiceSpecBase
    {
        protected IGameApplicationService GameApplicationService;
        protected IGameRepository GameRepository;
        protected IPlayerRepository PlayerRepository;

        [TestInitialize]
        public void Initialize()
        {
            GameRepository = new InMemoryGameRepository();
            GameApplicationService = new GameApplicationService(GameRepository);
            PlayerRepository = new InMemoryPlayerRepository();
        }

        protected List<PlayerId> GetPlayers(int numberOfPlayers)
        {
            var players = new List<PlayerId>();

            for (var i = 1; i <= numberOfPlayers; i++)
                players.Add(new PlayerId("player" + i));

            return players;
        }

    }
}
