using GoFish.Domain.Games;
using GoFish.Domain.Games.Events;
using GoFish.Domain.Games.States;
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
    public class RequestCardTests : GameTestsBase
    {
        [TestMethod]
        public void When_PlayerRequestsCard_AndItIsNotTheirTurn_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            var requestor = players[1];
            var requestee = players[0];

            var cardRequest = new CardRequest(requestor, requestee, CardRank.Ace);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.PlayerRequestCard(cardRequest), "It is not your turn.");
        }

        [TestMethod]
        public void When_PlayerRequestsCard_AndTheRequesteeIsNotPlaying_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            var requestor = players[0];
            var requestee = new PlayerId("non player");

            var requestorCards = game.Players.Single(x => x.PlayerId == requestor).Cards;
            var cardToRequest = game.Stock.First(x => requestorCards.Any(c => c.Rank == x.Rank));
            var cardRequest = new CardRequest(requestor, requestee, cardToRequest.Rank);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.PlayerRequestCard(cardRequest), "Requestee is not a player in this game.");
        }

        [TestMethod]
        public void When_PlayerRequestsCardTheyDoNotHave_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            var requestor = players[0];
            var requestee = players[1];

            var requestorCards = game.Players.Single(x => x.PlayerId == requestor).Cards;
            var cardTheyDontHave = game.Stock.First(x => !requestorCards.Any(c => c.Rank == x.Rank));

            var cardRequest = new CardRequest(requestor, requestee, cardTheyDontHave.Rank);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.PlayerRequestCard(cardRequest), "You can only request cards that you have.");
        }

        [TestMethod]
        public void When_PlayerRequestsCardFromThemself_ExceptionIsThrown()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            var requestor = players[0];
            var requestee = players[0];

            var requestorCards = game.Players.Single(x => x.PlayerId == requestor).Cards;
            var cardToRequest = game.Stock.First(x => requestorCards.Any(c => c.Rank == x.Rank));

            var cardRequest = new CardRequest(requestor, requestee, cardToRequest.Rank);

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                game.PlayerRequestCard(cardRequest), "You cannot request cards from yourself.");
        }

        [TestMethod]
        public void When_PlayerRequestsCard_RequestIsMade()
        {
            var players = GetSpecifiedNumberOfPlayers(2);
            var game = new Game(new GameId("newGame"), players, new CardDeck());

            var requestor = players[0];
            var requestee = players[1];

            var requestorCards = game.Players.Single(x => x.PlayerId == requestor).Cards;
            var cardToRequest = game.Stock.First(x => requestorCards.Any(c => c.Rank == x.Rank));
            var cardRequest = new CardRequest(requestor, requestee, cardToRequest.Rank);

            game.PlayerRequestCard(cardRequest);

            var expectedEvent = new CardRequested(game.GameId, cardRequest);
            var actualEvent = (CardRequested)game.Events.Single();
            var gameState = (CardRequestedState)game.State;

            Assert.AreEqual(cardRequest, gameState.CardRequest);
            Assert.AreEqual(requestee.Id, game.PlayerTurn.Id);
            Assert.AreEqual(expectedEvent.GameId, actualEvent.GameId);
            Assert.AreEqual(expectedEvent.CardRequest, actualEvent.CardRequest);
        }
    }
}
