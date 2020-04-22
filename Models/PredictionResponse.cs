using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApi.Models
{
    public class PredictionResponse
    {
        public int Id { get; set; }

        public int? GoalsLocal { get; set; }

        public int? GoalsVisitor { get; set; }

        public int Points { get; set; }

        public MatchResponse Match { get; set; }
    }
}
