using GoFish.Application.Games;
using GoFish.Application.Games.Commands;
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

        [Ignore]
        [TestMethod]
        public void When_New_Game_Started_With_Two_Players_Each_Player_Gets_Seven_Cards()
        {
            var player1 = new Player(new PlayerId("player1"));
            var player2 = new Player(new PlayerId("player2"));

            _playerRepository.Save(player1);
            _playerRepository.Save(player2);

            var newGame = new StartNewGame(new List<string> { player1.PlayerId.ToString(), player2.PlayerId.ToString() });

            var gameId = _gameApplicationService.StartNewGame(newGame);

            var game = _gameApplicationService.GetGame(gameId);

            Assert.AreEqual(gameId, game.Id);
            Assert.AreEqual(2, game.Players.Count);
            Assert.AreEqual(7, game.Players.Single(p => p.Key.Id == player1.PlayerId.ToString()).Value.Count());
            Assert.AreEqual(7, game.Players.Single(p => p.Key.Id == player2.PlayerId.ToString()).Value.Count());
            Assert.AreEqual(38, game.Stock.Count);
        }
    }
}
