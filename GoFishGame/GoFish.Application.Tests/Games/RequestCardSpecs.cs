using GoFish.Application.Games.Commands;
using GoFish.Application.Tests.Common;
using GoFish.Domain.Games;
using GoFish.Domain.Games.Events;
using GoFish.Domain.Games.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GoFish.Application.Tests.Games
{
    [TestClass]
    public class RequestCardSpecs : GameApplicationServiceSpecBase
    {
        [TestMethod]
        public void Given_GameStarted_When_PlayerRequestsCardFromAnotherPlayer_Then_CardIsRequested()
        {
            var game = GetStartedGame();

            var requestor = game.Players.Single(p => p.PlayerId.Equals(game.PlayerTurn));
            var requestee = game.Players.First(p => !p.PlayerId.Equals(requestor.PlayerId));
            var cardToRequest = requestor.Cards.First();

            var command = new RequestCard(
                game.GameId.ToString(),
                requestor.PlayerId.ToString(),
                requestee.PlayerId.ToString(),
                cardToRequest.Rank.ToString());

            GameApplicationService.RequestCard(command);

            game = GameRepository.Get(game.GameId);
            var gameState = (CardRequestedState)game.State;

            Assert.AreEqual(command.Requestor, gameState.CardRequest.Requestor.ToString());
            Assert.AreEqual(command.Requestee, gameState.CardRequest.Requestee.ToString());
            Assert.AreEqual(command.CardRank, gameState.CardRequest.CardRank.ToString());
        }

        [TestMethod]
        public void Given_GameStarted_When_PlayerRequestsCardTheyDontHave_Then_ExceptionIsThrown()
        {
            var game = GetStartedGame();

            var requestor = game.Players.Single(p=>p.PlayerId.Equals(game.PlayerTurn));
            var requestee = game.Players.First(p => !p.PlayerId.Equals(requestor.PlayerId));
            var cardToRequest = game.Stock.First(c => !requestor.Cards.Any(rc => rc.Rank.Equals(c.Rank)));

            var command = new RequestCard(
                game.GameId.ToString(),
                requestor.PlayerId.ToString(),
                requestee.PlayerId.ToString(),
                cardToRequest.Rank.ToString());

            ExceptionAssert.Throws<InvalidOperationException>(() =>
                GameApplicationService.RequestCard(command), "You can only request cards that you have.");
        }

        private Game GetStartedGame()
        {
            var players = GetPlayers(3);

            var gameId = GameApplicationService.StartNewGame(
                new StartNewGame(players.Select(p => p.ToString()).ToList()));

            var game = GameRepository.Get(new GameId(gameId));

            return game;
        }
    }
}
