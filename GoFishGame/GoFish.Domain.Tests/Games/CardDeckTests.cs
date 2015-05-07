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
            var cardDeck = new CardDeck();
            var firstDeck = cardDeck.GetShuffledCards();
            var secondDeck = cardDeck.GetShuffledCards();

            var cardsInSamePosition = 0;

            for(var i = 0; i < 52; i++)
            {
                if (firstDeck[i].Value == secondDeck[i].Value)
                    cardsInSamePosition++;
            }

            Assert.AreNotEqual(52, cardsInSamePosition);
        }
    }
}
