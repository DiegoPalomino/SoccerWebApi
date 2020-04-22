using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApi.Models
{
    public class TournamentResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public DateTime EndDate { get; set; }

        public DateTime EndDateLocal => EndDate.ToLocalTime();

        public bool IsActive { get; set; }

        public string LogoPath { get; set; }

        public string FinalPath => !string.IsNullOrEmpty(LogoPath) ? Path.GetFileName(LogoPath) : LogoPath;

        public string LogoFullPath => string.IsNullOrEmpty(FinalPath)
            ? "https://soccerwebapi.azurewebsites.net/images/noimage.png"
            : $"https://soccerwebapi.azurewebsites.net/images/tournaments/{FinalPath}";

        public List<GroupResponse> Groups { get; set; }
    }
}
