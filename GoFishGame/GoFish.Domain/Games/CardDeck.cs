using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class CardDeck
    {
        public CardDeck()
        {
            Cards = NewCardDeck();
        }

        public List<Card> Cards { get; private set; }

        public void Shuffle()
        {
            var newDeck = NewCardDeck();
            var shuffledCards = new List<Card>();
            var random = new Random();

            while(shuffledCards.Count < 52)
            {
                var cardIndex = random.Next(0, newDeck.Count - 1);
                shuffledCards.Add(newDeck[cardIndex]);
                newDeck.RemoveAt(cardIndex);
            }

            Cards = shuffledCards;
        }

        private static List<Card> NewCardDeck()
        {
            return new List<Card>
            {
                new Card(CardValue.TwoHearts),
                new Card(CardValue.TwoClubs),
                new Card(CardValue.TwoSpades),
                new Card(CardValue.TwoDiamonds),
                new Card(CardValue.ThreeHearts),
                new Card(CardValue.ThreeClubs),
                new Card(CardValue.ThreeSpades),
                new Card(CardValue.ThreeDiamonds),
                new Card(CardValue.FourHearts),
                new Card(CardValue.FourClubs),
                new Card(CardValue.FourSpades),
                new Card(CardValue.FourDiamonds),
                new Card(CardValue.FiveHearts),
                new Card(CardValue.FiveClubs),
                new Card(CardValue.FiveSpades),
                new Card(CardValue.FiveDiamonds),
                new Card(CardValue.SixHearts),
                new Card(CardValue.SixClubs),
                new Card(CardValue.SixSpades),
                new Card(CardValue.SixDiamonds),
                new Card(CardValue.SevenHearts),
                new Card(CardValue.SevenClubs),
                new Card(CardValue.SevenSpades),
                new Card(CardValue.SevenDiamonds),
                new Card(CardValue.EightHearts),
                new Card(CardValue.EightClubs),
                new Card(CardValue.EightSpades),
                new Card(CardValue.EightDiamonds),
                new Card(CardValue.NineHearts),
                new Card(CardValue.NineClubs),
                new Card(CardValue.NineSpades),
                new Card(CardValue.NineDiamonds),
                new Card(CardValue.TenHearts),
                new Card(CardValue.TenClubs),
                new Card(CardValue.TenSpades),
                new Card(CardValue.TenDiamonds),
                new Card(CardValue.JackHearts),
                new Card(CardValue.JackClubs),
                new Card(CardValue.JackSpades),
                new Card(CardValue.JackDiamonds),
                new Card(CardValue.QueenHearts),
                new Card(CardValue.QueenClubs),
                new Card(CardValue.QueenSpades),
                new Card(CardValue.QueenDiamonds),
                new Card(CardValue.KingHearts),
                new Card(CardValue.KingClubs),
                new Card(CardValue.KingSpades),
                new Card(CardValue.KingDiamonds),
                new Card(CardValue.AceHearts),
                new Card(CardValue.AceClubs),
                new Card(CardValue.AceSpades),
                new Card(CardValue.AceDiamonds)
            };
        }
    }
}
