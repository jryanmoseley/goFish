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

        #region New Game

        [TestMethod]
        public void When_NewGameIsCreated_WithLessThanTwoPlayers_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(1);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                new Game(new GameId("newGame"), players), "New game requires two to five players.");
        }

        [TestMethod]
        public void When_NewGameIsCreated_WithMoreThanFivePlayers_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(6);            

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                new Game(new GameId("newGame"), players), "New game requires two to five players.");
        }

        [TestMethod]
        public void When_NewGameIsCreated_With_Two_Players_Each_Player_Gets_Seven_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players);

            AssertGameStartedCorrectly(game, players, 2, 7, 38);
        }


        [TestMethod]
        public void When_NewGameIsCreated_With_Three_Players_Each_Player_Gets_Seven_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(3);
            var game = new Game(new GameId("newGame"), players);

            AssertGameStartedCorrectly(game, players, 3, 7, 31);
        }

        [TestMethod]
        public void When_NewGameIsCreated_With_Four_Players_Each_Player_Gets_Five_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(4);
            var game = new Game(new GameId("newGame"), players);

            AssertGameStartedCorrectly(game, players, 4, 5, 32);
        }

        [TestMethod]
        public void When_NewGameIsCreated_With_Five_Players_Each_Player_Gets_Five_Cards()
        {
            var players = GetSpecifiedNumberOfPlayers(5);
            var game = new Game(new GameId("newGame"), players);

            AssertGameStartedCorrectly(game, players, 5, 5, 27);
        }

        [TestMethod]
        public void When_NewGameIsStarted_Turns_Are_Established()
        {
            var players = GetSpecifiedNumberOfPlayers(3);
            var game = new Game(new GameId("newGame"),players);

            var turnOrder = game.TurnOrder;

            Assert.AreEqual(players[0].Id, game.PlayerTurn.Id);
            Assert.AreEqual(players[0].Id, turnOrder[0].Id);
            Assert.AreEqual(players[1].Id, turnOrder[1].Id);
            Assert.AreEqual(players[2].Id, turnOrder[2].Id);
        }

#endregion

        #region Requesting Cards

        [TestMethod]
        public void When_PlayerRequestsCard_AndItIsNotTheirTurn_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players);

            var requestor = players[1];
            var requestee = players[0];

            var cardRequest = new CardRequest(requestor, requestee, CardValue.Ace);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.PlayerRequestCards(cardRequest), "It is not your turn.");
        }

        [TestMethod]
        public void When_PlayerRequestsCardTheyDoNotHave_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players);

            var requestor = players[0];
            var requestee = players[1];

            var cardTheyDontHave = game.Stock.First(x => !game.Players[requestor].Any(c => c.Value == x.Value));

            var cardRequest = new CardRequest(requestor, requestee, cardTheyDontHave.Value);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.PlayerRequestCards(cardRequest), "You can only request cards that you have.");
        }

        [Ignore]
        [TestMethod]
        public void When_PlayerRequestsCardFromThemself_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players);

            var requestor = players[0];
            var requestee = players[0];

            var cardTheyDoHave = game.Stock.First(x => game.Players[requestor].Any(c => c.Value == x.Value));

            var cardRequest = new CardRequest(requestor, requestee, cardTheyDoHave.Value);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.PlayerRequestCards(cardRequest), "You cannot request cards from yourself.");
        }

        [TestMethod]
        public void When_PlayerRequestsCard_RequestIsMade_And_ItBecomesRequesteeTurn()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players);

            var requestor = players[0];
            var requestee = players[1];

            var cardTheyDoHave = game.Stock.First(x => game.Players[requestor].Any(c => c.Value == x.Value));

            var cardRequest = new CardRequest(requestor, requestee, cardTheyDoHave.Value);

            game.PlayerRequestCards(cardRequest);

            Assert.AreEqual(cardRequest, game.CurrentRequest);
            Assert.AreEqual(requestee.Id, game.PlayerTurn.Id);
        }

        #endregion

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
