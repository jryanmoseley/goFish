using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games.States
{
    public class CardRequestedState : GameState
    {
        public CardRequest CardRequest { get; private set; }

        public CardRequestedState(CardRequest cardRequest)
        {
            CardRequest = cardRequest;
        }
    }
}
