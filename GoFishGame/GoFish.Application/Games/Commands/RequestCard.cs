using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Games.Commands
{
    public class RequestCard
    {
        public string GameId { get; private set; }
        public string Requestor { get; private set; }
        public string Requestee { get; private set; }
        public string CardRank { get; private set; }

        public RequestCard(string gameId, string requestor, string requestee, string cardRank)
        {
            GameId = gameId;
            Requestor = requestor;
            Requestee = requestee;
            CardRank = cardRank;
        }
    }
}
