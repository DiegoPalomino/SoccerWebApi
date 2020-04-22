using Microsoft.AspNetCore.Http;
using SoccerWebApi.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SoccerWebApi.Models
{
    public class TournamentViewModel : TournamentEntity
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
