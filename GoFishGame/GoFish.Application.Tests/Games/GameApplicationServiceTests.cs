using GoFish.Application.Games;
using GoFish.Domain.Games;
using GoFish.Domain.Players;
using GoFish.Infrastructure.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Tests.Games
{
    [TestClass]
    public class GameApplicationServiceTests
    {
        private IGameApplicationService _gameApplicationService;
        private IGameRepository _gameRepository;
        private IPlayerRepository _playerRepository; 

        [TestInitialize]
        public void Initialize()
        {
            _gameRepository = new InMemoryGameRepository();
            _gameApplicationService = new GameApplicationService(_gameRepository);
            _playerRepository = new InMemoryPlayerRepository();
        }

        [TestMethod]
        public void When_New_Game_Started_With_Two_Players__Each_Player_Gets_Seven_Cards()
        {
            var player1 = new Player(new PlayerId("player1"));
            var player2 = new Player(new PlayerId("player2"));


        }
    }
}
