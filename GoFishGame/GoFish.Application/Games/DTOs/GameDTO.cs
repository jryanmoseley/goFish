using GoFish.Application.Players.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Games.DTOs
{
    public class GameDTO
    {
        public string Id { get; set; }
        public Dictionary<PlayerDTO, List<CardDTO>> Players { get; set; }
        public List<CardDTO> Stock { get; set; }
    }
}
