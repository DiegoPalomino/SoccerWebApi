using System.ComponentModel.DataAnnotations;

namespace SoccerWebApi.Data.Entities
{
    public class PredictionEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public MatchEntity Match { get; set; }

        [Display(Name = "Goals Local")]
        public int? GoalsLocal { get; set; }

        [Display(Name = "Goals Visitor")]
        public int? GoalsVisitor { get; set; }

        public int Points { get; set; }
    }
}
