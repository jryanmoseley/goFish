using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class CardDeck
    {
        private static Random _random;

        public CardDeck()
        {
            _random = new Random();
        }

        public List<Card> GetShuffledCards()
        {
            var newDeck = NewCardDeck();
            var shuffledCards = ShuffleCards(newDeck);
            return shuffledCards;
        }

        private static List<Card> ShuffleCards(List<Card> cards)
        {
            var shuffledCards = new List<Card>();

            while (shuffledCards.Count < 52)
            {
                var cardIndex = _random.Next(0, cards.Count - 1);
                shuffledCards.Add(cards[cardIndex]);
                cards.RemoveAt(cardIndex);
            }

            return shuffledCards;
        }

        private static List<Card> NewCardDeck()
        {
            return new List<Card>
            {
                new Card(CardRank.Two,CardSuit.Hearts),
                new Card(CardRank.Two,CardSuit.Clubs),
                new Card(CardRank.Two,CardSuit.Spades),
                new Card(CardRank.Two,CardSuit.Diamonds),
                new Card(CardRank.Three,CardSuit.Hearts),
                new Card(CardRank.Three,CardSuit.Clubs),
                new Card(CardRank.Three,CardSuit.Spades),
                new Card(CardRank.Three,CardSuit.Diamonds),
                new Card(CardRank.Four,CardSuit.Hearts),
                new Card(CardRank.Four,CardSuit.Clubs),
                new Card(CardRank.Four,CardSuit.Spades),
                new Card(CardRank.Four,CardSuit.Diamonds),
                new Card(CardRank.Five,CardSuit.Hearts),
                new Card(CardRank.Five,CardSuit.Clubs),
                new Card(CardRank.Five,CardSuit.Spades),
                new Card(CardRank.Five,CardSuit.Diamonds),
                new Card(CardRank.Six,CardSuit.Hearts),
                new Card(CardRank.Six,CardSuit.Clubs),
                new Card(CardRank.Six,CardSuit.Spades),
                new Card(CardRank.Six,CardSuit.Diamonds),
                new Card(CardRank.Seven,CardSuit.Hearts),
                new Card(CardRank.Seven,CardSuit.Clubs),
                new Card(CardRank.Seven,CardSuit.Spades),
                new Card(CardRank.Seven,CardSuit.Diamonds),
                new Card(CardRank.Eight,CardSuit.Hearts),
                new Card(CardRank.Eight,CardSuit.Clubs),
                new Card(CardRank.Eight,CardSuit.Spades),
                new Card(CardRank.Eight,CardSuit.Diamonds),
                new Card(CardRank.Nine,CardSuit.Hearts),
                new Card(CardRank.Nine,CardSuit.Clubs),
                new Card(CardRank.Nine,CardSuit.Spades),
                new Card(CardRank.Nine,CardSuit.Diamonds),
                new Card(CardRank.Ten,CardSuit.Hearts),
                new Card(CardRank.Ten,CardSuit.Clubs),
                new Card(CardRank.Ten,CardSuit.Spades),
                new Card(CardRank.Ten,CardSuit.Diamonds),
                new Card(CardRank.Jack,CardSuit.Hearts),
                new Card(CardRank.Jack,CardSuit.Clubs),
                new Card(CardRank.Jack,CardSuit.Spades),
                new Card(CardRank.Jack,CardSuit.Diamonds),
                new Card(CardRank.Queen,CardSuit.Hearts),
                new Card(CardRank.Queen,CardSuit.Clubs),
                new Card(CardRank.Queen,CardSuit.Spades),
                new Card(CardRank.Queen,CardSuit.Diamonds),
                new Card(CardRank.King,CardSuit.Hearts),
                new Card(CardRank.King,CardSuit.Clubs),
                new Card(CardRank.King,CardSuit.Spades),
                new Card(CardRank.King,CardSuit.Diamonds),
                new Card(CardRank.Ace,CardSuit.Hearts),
                new Card(CardRank.Ace,CardSuit.Clubs),
                new Card(CardRank.Ace,CardSuit.Spades),
                new Card(CardRank.Ace,CardSuit.Diamonds)
            };
        }
    }
}
