using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Games.Commands
{
    public class StartNewGame
    {
        public List<string> PlayerIds { get; private set; }

        public StartNewGame(List<string> playerIds)
        {
            PlayerIds = playerIds;
        }
    }
}
