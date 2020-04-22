using SoccerWebApi.Data;
using SoccerWebApi.Data.Entities;
using SoccerWebApi.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly Random _random;

        public SeedDb(
            DataContext context,
            IBlobHelper blobHelper)
        {
            _context = context;
            _blobHelper = blobHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTeamsAsync();
            await CheckTournamentsAsync();
            await CheckPreditionsAsync();
        }

        private List<Photo> LoadPhotos()
        {
            return new List<Photo>
            {
                new Photo { FirstName = "Adala", Name = "Samir", Image = "Adala.jpg" },
                new Photo { FirstName = "Amalia", Name = "Lopez", Image = "Amalia.jpg" },
                new Photo { FirstName = "Camila", Name = "Cardona", Image = "Camila.jpg" },
                new Photo { FirstName = "Carolina", Name = "Echavarria", Image = "Carolina.jpg" },
                new Photo { FirstName = "Claudia", Name = "Sanchez", Image = "Claudia.jpg" },
                new Photo { FirstName = "Gilberto", Name = "Medez", Image = "Gilberto.jpg" },
                new Photo { FirstName = "Jhon", Name = "Smith", Image = "Jhon.jpg" },
                new Photo { FirstName = "Ken", Name = "Rogers", Image = "Ken.jpg" },
                new Photo { FirstName = "Laura", Name = "Zuluaga", Image = "Laura.jpg" },
                new Photo { FirstName = "Luisa", Name = "Zapata", Image = "Luisa.jpg" },
                new Photo { FirstName = "Manuelm", Name = "Rodriguez", Image = "Manuel.jpg" },
                new Photo { FirstName = "Manuela", Name = "Ateortua", Image = "Manuela.jpg" },
                new Photo { FirstName = "Mario", Name = "Bedoya", Image = "Mario.jpg" },
                new Photo { FirstName = "Monica", Name = "Cano", Image = "Monica.jpg" },
                new Photo { FirstName = "Pedro", Name = "Correa", Image = "Pedro.jpg" },
                new Photo { FirstName = "Penelope", Name = "Arias", Image = "Penelope.jpg" },
                new Photo { FirstName = "Pepe", Name = "Lopez", Image = "Pepe.jpg" },
                new Photo { FirstName = "Raul", Name = "Matinez", Image = "Raul.jpg" },
                new Photo { FirstName = "Roberto", Name = "Rivas", Image = "Roberto.jpg" },
                new Photo { FirstName = "Rosa", Name = "Velasquez", Image = "Rosa.jpg" },
                new Photo { FirstName = "Rosario", Name = "Sandoval", Image = "Rosario.jpg" },
                new Photo { FirstName = "Sandra", Name = "Machado", Image = "Sandra.jpg" },
                new Photo { FirstName = "Sandro", Name = "Ruiz", Image = "Sandro.jpg" },
                new Photo { FirstName = "Teresa", Name = "Santamaria", Image = "Teresa.jpg" }
            };
        }

        private async Task CheckPreditionsAsync()
        {
            if (!_context.Predictions.Any())
            {
                List<Photo> photos = LoadPhotos();
                foreach (Photo photo in photos)
                {
                    AddPrediction($"{photo.FirstName}.{photo.Name}@yopmail.com");
                }

                await _context.SaveChangesAsync();
            }
        }

        private void AddPrediction(string email)
        {
            foreach (MatchEntity match in _context.Matches)
            {
                _context.Predictions.Add(new PredictionEntity
                {
                    GoalsLocal = _random.Next(0, 5),
                    GoalsVisitor = _random.Next(0, 5),
                    Match = match,
                    Email = email
                });
            }
        }

        private async Task CheckTeamsAsync()
        {
            if (!_context.Teams.Any())
            {
                /*await AddTeamAsync("Ajax");
                await AddTeamAsync("America");
                await AddTeamAsync("Argentina");
                await AddTeamAsync("Barcelona");
                await AddTeamAsync("Bayer Leverkusen");
                await AddTeamAsync("Bolivia");
                await AddTeamAsync("Borussia Dortmund");
                await AddTeamAsync("Brasil");
                await AddTeamAsync("Bucaramanga");
                await AddTeamAsync("Canada");
                await AddTeamAsync("Chelsea");
                await AddTeamAsync("Chile");
                await AddTeamAsync("Colombia");
                await AddTeamAsync("Costa Rica");
                await AddTeamAsync("Ecuador");
                await AddTeamAsync("Honduras");
                await AddTeamAsync("Inter Milan");
                await AddTeamAsync("Junior");
                await AddTeamAsync("Juventus");
                await AddTeamAsync("Liverpool");
                await AddTeamAsync("Medellin");
                await AddTeamAsync("Mexico");
                await AddTeamAsync("Millonarios");
                await AddTeamAsync("Nacional");
                await AddTeamAsync("Once Caldas");
                await AddTeamAsync("Panama");
                await AddTeamAsync("Paraguay");
                await AddTeamAsync("Peru");
                await AddTeamAsync("PSG");
                await AddTeamAsync("Real Madrid");
                await AddTeamAsync("Santa Fe");
                await AddTeamAsync("Uruguay");
                await AddTeamAsync("USA");
                await AddTeamAsync("Venezuela");*/

                AddTeam("Ajax");
                AddTeam("America");
                AddTeam("Argentina");
                AddTeam("Barcelona");
                AddTeam("Bayer Leverkusen");
                AddTeam("Bolivia");
                AddTeam("Borussia Dortmund");
                AddTeam("Brasil");
                AddTeam("Bucaramanga");
                AddTeam("Canada");
                AddTeam("Chelsea");
                AddTeam("Chile");
                AddTeam("Colombia");
                AddTeam("Costa Rica");
                AddTeam("Ecuador");
                AddTeam("Honduras");
                AddTeam("Inter Milan");
                AddTeam("Junior");
                AddTeam("Juventus");
                AddTeam("Liverpool");
                AddTeam("Medellin");
                AddTeam("Mexico");
                AddTeam("Millonarios");
                AddTeam("Nacional");
                AddTeam("Once Caldas");
                AddTeam("Panama");
                AddTeam("Paraguay");
                AddTeam("Peru");
                AddTeam("PSG");
                AddTeam("Real Madrid");
                AddTeam("Santa Fe");
                AddTeam("Uruguay");
                AddTeam("USA");
                AddTeam("Venezuela");

                await _context.SaveChangesAsync();
            }
        }

        private async Task AddTeamAsync(string name)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\Teams", $"{name}.jpg");
            string imageId = await _blobHelper.UploadBlobAsync(path, "teams");
            _context.Teams.Add(new TeamEntity { Name = name, LogoPath = imageId }); 
        }

        private void AddTeam(string name)
        {
            _context.Teams.Add(new TeamEntity { Name = name, LogoPath = $"~/images/Teams/{name}.jpg" });
        }

        private async Task CheckTournamentsAsync()
        {
            if (!_context.Tournaments.Any())
            {
                DateTime startDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                DateTime endDate = DateTime.Today.AddMonths(3).ToUniversalTime();

                string imageIdCopaAmerica = await UploadImageTournamentAsync("Copa America 2020.png");
                string imageIdLigaAguila = await UploadImageTournamentAsync("Liga Aguila 2020-I.png");
                string imageIdChampions = await UploadImageTournamentAsync("Champions 2020.png");

                _context.Tournaments.Add(new TournamentEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    IsActive = true,
                    LogoPath = imageIdCopaAmerica,
                    Name = "Copa America 2020",
                    Groups = new List<GroupEntity>
                    {
                        new GroupEntity
                        {
                             Name = "A",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Colombia") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Panama") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Canada") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Panama"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Canada")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Panama")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Canada")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Canada"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Colombia")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Panama")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "B",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Argentina") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Mexico") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Chile") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Mexico"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chile")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chile")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Chile"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Argentina")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "C",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Brasil") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "USA") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Peru") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(2).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(2).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "USA"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Peru")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(6).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "USA")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(6).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Peru")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(11).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Peru"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Brasil")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(11).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "USA")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "D",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Honduras") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(3).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(3).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(7).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(7).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(12).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Honduras"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(12).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                 }
                             }
                        }
                    }
                });

                startDate = DateTime.Today.AddMonths(1).ToUniversalTime();
                endDate = DateTime.Today.AddMonths(4).ToUniversalTime();

                _context.Tournaments.Add(new TournamentEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    IsActive = true,
                    LogoPath = imageIdLigaAguila,
                    Name = "Liga Aguila 2020-I",
                    Groups = new List<GroupEntity>
                    {
                        new GroupEntity
                        {
                             Name = "A",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "America") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Bucaramanga") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Junior") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Medellin") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "America"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Bucaramanga")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Junior"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Medellin")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "America"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Junior")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bucaramanga"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Medellin")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Medellin"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "America")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bucaramanga"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Junior")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(15).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bucaramanga"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "America")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(15).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Medellin"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Junior")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Junior"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "America")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Medellin"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Bucaramanga")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "America"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Medellin")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Junior"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Bucaramanga")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "B",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Millonarios") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Nacional") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Once Caldas") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Santa Fe") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Millonarios"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Nacional")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Once Caldas"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Santa Fe")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Millonarios"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Once Caldas")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Nacional"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Santa Fe")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Santa Fe"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Millonarios")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Nacional"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Once Caldas")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(16).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Nacional"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Millonarios")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(16).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Santa Fe"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Once Caldas")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(20).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Once Caldas"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Millonarios")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(20).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Santa Fe"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Nacional")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(35).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Millonarios"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Santa Fe")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(35).AddHours(16),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Once Caldas"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Nacional")
                                 }
                             }
                        }
                    }
                });

                startDate = DateTime.Today.AddMonths(1).ToUniversalTime();
                endDate = DateTime.Today.AddMonths(2).ToUniversalTime();

                _context.Tournaments.Add(new TournamentEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    IsActive = true,
                    LogoPath = imageIdChampions,
                    Name = "Champions 2020",
                    Groups = new List<GroupEntity>
                    {
                        new GroupEntity
                        {
                             Name = "A",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Ajax") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Barcelona") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Ajax"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Barcelona")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Barcelona"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Ajax")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "B",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Bayer Leverkusen") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Chelsea") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Bayer Leverkusen"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chelsea")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Bayer Leverkusen")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "C",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Borussia Dortmund") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Inter Milan") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Borussia Dortmund"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Inter Milan")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Inter Milan"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Borussia Dortmund")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "D",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "PSG") },
                                 new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Real Madrid") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "PSG"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Real Madrid")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _context.Teams.FirstOrDefault(t => t.Name == "Real Madrid"),
                                     Visitor = _context.Teams.FirstOrDefault(t => t.Name == "PSG")
                                 }
                             }
                        }
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task<string> UploadImageTournamentAsync(string name)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\Tournaments", name);
            return await _blobHelper.UploadBlobAsync(path, "tournaments");
        }

        private class Photo
        {
            public string FirstName { get; set; }

            public string Name { get; set; }

            public string Image { get; set; }
        }
    }
}
