using GoFish.Application.Games.Commands;
using GoFish.Domain.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Games
{
    public class GameApplicationService : IGameApplicationService
    {
        private readonly IGameRepository _gameRepository;

        public GameApplicationService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public string StartNewGame(StartNewGame game)
        {
            return string.Empty;
        }
    }
}
