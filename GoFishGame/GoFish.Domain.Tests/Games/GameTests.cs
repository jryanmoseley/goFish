using GoFish.Domain.Games;
using GoFish.Domain.Players;
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
        [Ignore]
        [TestMethod]
        public void When_New_Game_Started_With_Two_Players_Each_Player_Gets_Seven_Cards()
        {
            var game = new Game(new GameId("newGame"));

            var player1 = new PlayerId("player1");
            var player2 = new PlayerId("player2");

            var players = new List<PlayerId> { player1, player2 };
            game.StartNewGame(players);

            Assert.AreEqual(2, game.Players.Count);
            Assert.AreEqual(7, game.Players.Single(p => p.Key.Id == player1.Id.ToString()).Value.Count());
            Assert.AreEqual(7, game.Players.Single(p => p.Key.Id == player2.Id.ToString()).Value.Count());
            Assert.AreEqual(38, game.Stock.Count);
        }
    }
}
