using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApi.Models
{
    public class PositionResponse
    {
        public UserResponse UserResponse { get; set; }

        public int Points { get; set; }

        public int Ranking { get; set; }
    }
}
