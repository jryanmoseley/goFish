using GoFish.Application.Games.Commands;
using GoFish.Application.Games.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Games
{
    public interface IGameApplicationService
    {
        string StartNewGame(StartNewGame command);
        void RequestCard(RequestCard command);
    }
}
