﻿using GoFish.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Games
{
    interface IGameRepository<Game> : IRepository<Game>
    {
    }
}
