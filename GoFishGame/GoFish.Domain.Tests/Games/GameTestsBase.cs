using GoFish.Domain.Games;
using GoFish.Domain.Games.Events;
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
    public class GameTestsBase
    {
        protected static List<PlayerId> GetSpecifiedNumberOfPlayers(int numberOfPlayers)
        {
            var players = new List<PlayerId>();

            for (var i = 1; i <= numberOfPlayers; i++)
                players.Add(new PlayerId("player" + i));

            return players;
        }
    }
}
