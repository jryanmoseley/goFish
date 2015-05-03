using GoFish.Domain.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Tests.Games
{
    [TestClass]
    public class CardDeckTests
    {
        [TestMethod]
        public void Can_Shuffle_CardDeck()
        {
            var deck = new CardDeck();

            var deckBeforeShuffle = deck.Cards;

            deck.Shuffle();

            var deckAfterShuffle = deck.Cards;

            var cardsInSamePosition = 0;

            for(var i = 0; i < 52; i++)
            {
                if (deckBeforeShuffle[i].Value == deckAfterShuffle[i].Value)
                    cardsInSamePosition++;
            }

            Assert.AreNotEqual(52, cardsInSamePosition);
        }
    }
}
