using GoFish.Domain.Common;
using GoFish.Domain.Games;
using GoFish.Domain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Infrastructure.InMemory
{
    public class InMemoryGameRepository : IGameRepository
    {
        private static Dictionary<string, Game> _games;

        public InMemoryGameRepository()
        {
            _games = new Dictionary<string, Game>();
        }

        public void Save(Game game)
        {
            _games[game.GameId.ToString()] = game;
        }

        public IEnumerable<Game> GetAll()
        {
            return _games.Values.ToList();
        }

        public Game Get(GameId id)
        {
            return _games[id.ToString()];
        }
    }
}
