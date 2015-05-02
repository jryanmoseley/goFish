using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Players
{
    public class Player
    {
        private PlayerId Id;

        public Player(PlayerId id)
        {
            Id = id;
        }
    }
}
