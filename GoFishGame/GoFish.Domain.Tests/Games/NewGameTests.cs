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
    public class NewGameTests : GameTestsBase
    {
        [TestMethod]
        public void When_NewGameIsCreated_WithLessThanTwoPlayers_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(1);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                new Game(new GameId("newGame"), players, new CardDeck()), "New game requires two to five players.");
        }

        [TestMethod]
        public void When_NewGameIsCreated_WithMoreThanFivePlayers_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(6);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                new Game(new GameId("newGame"), players, new CardDeck()), "New game requires two to five players.");
        }

        [TestMethod]
        public void When_NewGameIsCreated_With_Two_Players_Each_Player_Gets_Seven_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            AssertGameStartedCorrectly(game, players, 2, 7, 38);
        }

        [TestMethod]
        public void When_NewGameIsCreated_With_Three_Players_Each_Player_Gets_Seven_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(3);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            AssertGameStartedCorrectly(game, players, 3, 7, 31);
        }

        [TestMethod]
        public void When_NewGameIsCreated_With_Four_Players_Each_Player_Gets_Five_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(4);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            AssertGameStartedCorrectly(game, players, 4, 5, 32);
        }

        [TestMethod]
        public void When_NewGameIsCreated_With_Five_Players_Each_Player_Gets_Five_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(5);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            AssertGameStartedCorrectly(game, players, 5, 5, 27);
        }

        [TestMethod]
        public void When_NewGameIsStarted_Turns_Are_Established()
        {
            var players = GetSpecifiedNumberOfPlayers(3);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            var turnOrder = game.TurnOrder;

            Assert.AreEqual(players[0].Id, game.PlayerTurn.Id);
            Assert.AreEqual(players[0].Id, turnOrder[0].Id);
            Assert.AreEqual(players[1].Id, turnOrder[1].Id);
            Assert.AreEqual(players[2].Id, turnOrder[2].Id);
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
                Assert.AreEqual(expectedNumberOfPlayerCards, game.Players.Single(p => p.PlayerId == player).Cards.Count());
        }
    }
}
