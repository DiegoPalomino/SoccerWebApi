using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace SoccerWebApi.Data.Entities
{
    public class TeamEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        public string FinalPath => !string.IsNullOrEmpty(LogoPath) ? Path.GetFileName(LogoPath) : LogoPath;

        [Display(Name = "Logo")]
        public string LogoFullPath => string.IsNullOrEmpty(FinalPath)
            ? "https://soccerwebapi.azurewebsites.net/images/noimage.png"
            : $"https://soccerwebapi.azurewebsites.net/images/teams/{FinalPath}";
    }
}
