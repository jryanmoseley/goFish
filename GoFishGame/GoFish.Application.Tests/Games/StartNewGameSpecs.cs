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
    public class StartNewGameSpecs : GameApplicationServiceSpecBase
    {
        [TestMethod]
        public void Given_TwoPlayers_When_NewGameStarted_Then_EachPlayerReceivesSevenCards()
        {
            var players = GetPlayers(2);

            var command = new StartNewGame(players.Select(p => p.ToString()).ToList());
            var gameId = GameApplicationService.StartNewGame(command);

            var game = GameRepository.Get(new GameId(gameId));

            AssertGameStartedCorrectly(game, players, 2, 7, 38);
        }

        [TestMethod]
        public void Given_ThreePlayers_When_NewGameStarted_Then_EachPlayerReceivesSevenCards()
        {
            var players = GetPlayers(3);

            var command = new StartNewGame(players.Select(p => p.ToString()).ToList());
            var gameId = GameApplicationService.StartNewGame(command);

            var game = GameRepository.Get(new GameId(gameId));

            AssertGameStartedCorrectly(game, players, 3, 7, 31);
        }

        [TestMethod]
        public void Given_FourPlayers_When_NewGameStarted_Then_EachPlayerReceivesFiveCards()
        {
            var players = GetPlayers(4);

            var command = new StartNewGame(players.Select(p => p.ToString()).ToList());
            var gameId = GameApplicationService.StartNewGame(command);

            var game = GameRepository.Get(new GameId(gameId));

            AssertGameStartedCorrectly(game, players, 4, 5, 32);
        }

        [TestMethod]
        public void Given_FivePlayers_When_NewGameStarted_Then_EachPlayerReceivesFiveCards()
        {
            var players = GetPlayers(5);

            var command = new StartNewGame(players.Select(p => p.ToString()).ToList());
            var gameId = GameApplicationService.StartNewGame(command);

            var game = GameRepository.Get(new GameId(gameId));

            AssertGameStartedCorrectly(game, players, 5, 5, 27);
        }

        private void AssertGameStartedCorrectly(
            Game game,
            List<PlayerId> players,
            int expectedNumberOfPlayers,
            int expectedNumberOfPlayerCards,
            int expectedNumberOfStock)
        {
            Assert.IsNotNull(game);
            Assert.AreEqual(expectedNumberOfPlayers, game.Players.Count);
            Assert.AreEqual(expectedNumberOfStock, game.Stock.Count);
            Assert.IsTrue(game.Players.All(p => p.Cards.Count == expectedNumberOfPlayerCards));
        }
    }
}
