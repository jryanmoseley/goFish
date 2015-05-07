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
                new Card(CardValue.Two,CardSuit.Hearts),
                new Card(CardValue.Two,CardSuit.Clubs),
                new Card(CardValue.Two,CardSuit.Spades),
                new Card(CardValue.Two,CardSuit.Diamonds),
                new Card(CardValue.Three,CardSuit.Hearts),
                new Card(CardValue.Three,CardSuit.Clubs),
                new Card(CardValue.Three,CardSuit.Spades),
                new Card(CardValue.Three,CardSuit.Diamonds),
                new Card(CardValue.Four,CardSuit.Hearts),
                new Card(CardValue.Four,CardSuit.Clubs),
                new Card(CardValue.Four,CardSuit.Spades),
                new Card(CardValue.Four,CardSuit.Diamonds),
                new Card(CardValue.Five,CardSuit.Hearts),
                new Card(CardValue.Five,CardSuit.Clubs),
                new Card(CardValue.Five,CardSuit.Spades),
                new Card(CardValue.Five,CardSuit.Diamonds),
                new Card(CardValue.Six,CardSuit.Hearts),
                new Card(CardValue.Six,CardSuit.Clubs),
                new Card(CardValue.Six,CardSuit.Spades),
                new Card(CardValue.Six,CardSuit.Diamonds),
                new Card(CardValue.Seven,CardSuit.Hearts),
                new Card(CardValue.Seven,CardSuit.Clubs),
                new Card(CardValue.Seven,CardSuit.Spades),
                new Card(CardValue.Seven,CardSuit.Diamonds),
                new Card(CardValue.Eight,CardSuit.Hearts),
                new Card(CardValue.Eight,CardSuit.Clubs),
                new Card(CardValue.Eight,CardSuit.Spades),
                new Card(CardValue.Eight,CardSuit.Diamonds),
                new Card(CardValue.Nine,CardSuit.Hearts),
                new Card(CardValue.Nine,CardSuit.Clubs),
                new Card(CardValue.Nine,CardSuit.Spades),
                new Card(CardValue.Nine,CardSuit.Diamonds),
                new Card(CardValue.Ten,CardSuit.Hearts),
                new Card(CardValue.Ten,CardSuit.Clubs),
                new Card(CardValue.Ten,CardSuit.Spades),
                new Card(CardValue.Ten,CardSuit.Diamonds),
                new Card(CardValue.Jack,CardSuit.Hearts),
                new Card(CardValue.Jack,CardSuit.Clubs),
                new Card(CardValue.Jack,CardSuit.Spades),
                new Card(CardValue.Jack,CardSuit.Diamonds),
                new Card(CardValue.Queen,CardSuit.Hearts),
                new Card(CardValue.Queen,CardSuit.Clubs),
                new Card(CardValue.Queen,CardSuit.Spades),
                new Card(CardValue.Queen,CardSuit.Diamonds),
                new Card(CardValue.King,CardSuit.Hearts),
                new Card(CardValue.King,CardSuit.Clubs),
                new Card(CardValue.King,CardSuit.Spades),
                new Card(CardValue.King,CardSuit.Diamonds),
                new Card(CardValue.Ace,CardSuit.Hearts),
                new Card(CardValue.Ace,CardSuit.Clubs),
                new Card(CardValue.Ace,CardSuit.Spades),
                new Card(CardValue.Ace,CardSuit.Diamonds)
            };
        }
    }
}
