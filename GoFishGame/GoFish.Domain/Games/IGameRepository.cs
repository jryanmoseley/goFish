using GoFish.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public interface IGameRepository
    {
        void Save(Game game);
        IEnumerable<Game> GetAll();
        Game Get(GameId gameId);
    }
}
