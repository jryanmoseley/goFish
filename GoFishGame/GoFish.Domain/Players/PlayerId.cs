using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Players
{
    public class PlayerId
    {
        public string Id { get; private set; }

        public PlayerId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidOperationException("Id is required");

            Id = id;
        }

        public override bool Equals(object obj)
        {
            var playerId = obj as PlayerId;
            if (playerId == null) return false;
            return Id == playerId.Id;
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
