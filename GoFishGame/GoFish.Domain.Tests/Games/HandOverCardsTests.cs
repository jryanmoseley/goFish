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
    public class HandOverCardsTests : GameTestsBase
    {
        //private Game _game;
        //private PlayerId _requestor;
        //private PlayerId _requestee;

        //[TestInitialize]
        //public void Setup()
        //{
        //    var players = GetSpecifiedNumberOfPlayers(2);
        //    _game = new Game(new GameId("newGame"), players, new CardDeck());

        //    _requestor = players[0];
        //    _requestee = players[1];

        //    var requestorCards = _game.Players.Single(x => x.PlayerId == _requestor).Cards;
        //    var cardToRequest = _game.Stock.First(x => requestorCards.Any(c => c.Value == x.Value));
        //    var cardRequest = new CardRequest(_requestor, _requestee, cardToRequest.Value);

        //    _game.PlayerRequestCard(cardRequest);
        //}

        //[TestMethod]
        //public void When_PlayerHandsOverCards_AndItIsNotTheirTurn_ExceptionIsThrown()
        //{
        //    var players = GetSpecifiedNumberOfPlayers(2);
        //    var game = new Game(new GameId("newGame"), players, new CardDeck());

        //    var requestor = players[1];
        //    var requestee = players[0];

        //    var cardRequest = new CardRequest(requestor, requestee, CardRank.Ace);

        //    ExceptionAssert.Throws<InvalidOperationException>(() =>
        //        game.PlayerRequestCard(cardRequest), "It is not your turn.");
        //}

        //[TestMethod]
        //public void When_CardRequestedThatRequesteeHas_AndHeHandsOverRequestedCards_CardsAreHandedOver()
        //{

        //}

    }
}
