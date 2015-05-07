using GoFish.Domain.Games;
using GoFish.Domain.Players;
using GoFish.Domain.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Tests.Games
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void When_StartNewGame_CalledWithLessThanTwoPlayers_ExceptionIsThrown()
        {
            var game = new Game(new GameId("newGame"));
            var players = GetSpecifiedNumberOfPlayers(1);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.StartNewGame(players), "New game requires two to five players.");
        }

        [TestMethod]
        public void When_StartNewGame_CalledWithMoreThanFivePlayers_ExceptionIsThrown()
        {
            var game = new Game(new GameId("newGame"));
            var players = GetSpecifiedNumberOfPlayers(6);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.StartNewGame(players), "New game requires two to five players.");
        }

        [TestMethod]
        public void When_StartNewGame_Called_With_Two_Players_Each_Player_Gets_Seven_Cards()
        {
            var game = new Game(new GameId("newGame"));
            var players = GetSpecifiedNumberOfPlayers(2);

            game.StartNewGame(players);

            AssertGameStartedCorrectly(game, players, 2, 7, 38);
        }


        [TestMethod]
        public void When_StartNewGame_Called_With_Three_Players_Each_Player_Gets_Seven_Cards()
        {
            var game = new Game(new GameId("newGame"));
            var players = GetSpecifiedNumberOfPlayers(3);

            game.StartNewGame(players);

            AssertGameStartedCorrectly(game, players, 3, 7, 31);
        }

        [TestMethod]
        public void When_StartNewGame_Called_With_Four_Players_Each_Player_Gets_Five_Cards()
        {
            var game = new Game(new GameId("newGame"));
            var players = GetSpecifiedNumberOfPlayers(4);

            game.StartNewGame(players);

            AssertGameStartedCorrectly(game, players, 4, 5, 32);
        }

        [TestMethod]
        public void When_StartNewGame_Called_With_Five_Players_Each_Player_Gets_Five_Cards()
        {
            var game = new Game(new GameId("newGame"));
            var players = GetSpecifiedNumberOfPlayers(5);

            game.StartNewGame(players);

            AssertGameStartedCorrectly(game, players, 5, 5, 27);
        }

        private static List<PlayerId> GetSpecifiedNumberOfPlayers(int numberOfPlayers)
        {
            var players = new List<PlayerId>();

            for(var i=1; i <= numberOfPlayers; i++)
                players.Add(new PlayerId("player" + i));

            return players;
        }

        private void AssertGameStartedCorrectly(
            Game game,
            List<PlayerId> players,
            int expectedNumberOfPlayers, 
            int expectedNumberOfPlayerCards, 
            int expectedNumberOfStock)
        {
            Assert.AreEqual(expectedNumberOfPlayers, game.Players.Count);

            Assert.AreEqual(expectedNumberOfStock, game.Stock.Count);

            foreach (var player in players)
                Assert.AreEqual(expectedNumberOfPlayerCards, game.Players.Single(p => p.Key.Id == player.Id.ToString()).Value.Count());
        }
    }
}
