using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class Card
    {
        public CardRank Value { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardRank cardValue, CardSuit cardSuit)
        {
            Value = cardValue;
            Suit = cardSuit;
        }
    }
}
