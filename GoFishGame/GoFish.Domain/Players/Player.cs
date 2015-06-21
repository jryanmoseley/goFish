﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Players
{
    public class Player
    {
        public PlayerId PlayerId { get; private set; }

        public Player(PlayerId id)
        {
            PlayerId = id;
        }
    }
}
