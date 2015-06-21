using GoFish.Domain.Players;

namespace GoFish.Domain.Games
{
    public class CardRequest
    {
        public PlayerId Requestor { get; private set; }
        public PlayerId Requestee { get; private set; }
        public CardRank CardRank { get; private set; }

        public CardRequest(PlayerId requestor, PlayerId requestee, CardRank cardRank)
        {
            Requestor = requestor;
            Requestee = requestee;
            CardRank = cardRank;
        }
    }
}
