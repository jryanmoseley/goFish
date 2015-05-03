using GoFish.Domain.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Infrastructure.InMemory
{
    public class InMemoryGameRepository : IGameRepository
    {
        public void Save(Game entity)
        {
            
        }

        public IEnumerable<Game> GetAll()
        {
            return new List<Game>();
        }

        public Game Get(string id)
        {
            return new Game(new GameId(id));
        }
    }
}
