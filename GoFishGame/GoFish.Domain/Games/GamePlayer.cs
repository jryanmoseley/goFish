using GoFish.Domain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class GamePlayer
    {
        public PlayerId PlayerId { get; private set; }
        public List<Card> Cards { get; private set; }

        public GamePlayer(PlayerId playerId)
        {
            PlayerId = playerId;
            Cards = new List<Card>();
        }

        public void DealCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
