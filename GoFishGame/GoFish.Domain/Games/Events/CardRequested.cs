using GoFish.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games.Events
{
    public class CardRequested : IDomainEvent
    {
        public CardRequested(GameId gameId, CardRequest cardRequest)
        {
            GameId = gameId;
            CardRequest = cardRequest;
        }

        public GameId GameId { get; private set; }
        public CardRequest CardRequest { get; private set; }
    }
}
