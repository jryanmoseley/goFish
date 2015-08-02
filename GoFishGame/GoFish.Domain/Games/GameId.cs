using GoFish.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    public class GameId
    {
        public string Id { get; private set; }

        public GameId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidOperationException("Game id is required.");

            Id = id;
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
