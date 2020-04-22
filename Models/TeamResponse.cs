using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApi.Models
{
    public class TeamResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoPath { get; set; }

        public string FinalPath => !string.IsNullOrEmpty(LogoPath) ? Path.GetFileName(LogoPath) : LogoPath;

        public string LogoFullPath => string.IsNullOrEmpty(FinalPath)
            ? "https://soccerwebapi.azurewebsites.net/images/noimage.png"
            : $"https://soccerwebapi.azurewebsites.net/images/tournaments/{FinalPath}";
    }
}
