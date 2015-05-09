using GoFish.Domain.Players;

namespace GoFish.Domain.Games
{
    public class CardRequest
    {
        public PlayerId Requestor { get; private set; }
        public PlayerId Requestee { get; private set; }
        public CardValue Card { get; private set; }

        public CardRequest(PlayerId requestor, PlayerId requestee, CardValue card)
        {
            Requestor = requestor;
            Requestee = requestee;
            Card = card;
        }
    }
}
