using GoFish.Domain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Infrastructure.InMemory
{
    public class InMemoryPlayerRepository : IPlayerRepository<Player>
    {
        public void Save(Player entity)
        {

        }

        public IEnumerable<Player> GetAll()
        {
            return new List<Player>();
        }

        public Player Get(string id)
        {
            return new Player();
        }
    }
}
