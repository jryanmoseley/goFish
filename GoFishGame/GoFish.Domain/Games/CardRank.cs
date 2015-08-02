using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public enum CardRank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public static class CardRankExtensions
    {
        public static CardRank ToEnum(string cardRank)
        {
            return (CardRank)Enum.Parse(typeof(CardRank), cardRank);
        }
    }
}
