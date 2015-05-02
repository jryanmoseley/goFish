using GoFish.Application.Games.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Games
{
    public interface IGameApplicationService
    {
        string StartNewGame(StartNewGame game);
    }
}
