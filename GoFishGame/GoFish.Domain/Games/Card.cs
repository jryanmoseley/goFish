using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class Card
    {
        public CardValue Value { get; private set; }

        public Card(CardValue cardValue)
        {
            Value = cardValue;
        }
    }
}
