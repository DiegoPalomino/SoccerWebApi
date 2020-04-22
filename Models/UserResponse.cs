using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApi.Models
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PicturePath { get; set; }

        public TeamResponse Team { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public string PictureFullPath => string.IsNullOrEmpty(PicturePath)
            ? "https://soccerwebapi.azurewebsites.net/images/noimage.png"
            : $"https://soccerwebapi.azurewebsites.net/images/users/{PicturePath}";
    }
}
