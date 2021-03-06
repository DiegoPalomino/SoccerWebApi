﻿using SoccerWebApi.Data.Entities;
using SoccerWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerWebApi.Helpers
{
    public interface IConverterHelper
    {
        PredictionResponse ToPredictionResponse(PredictionEntity predictionEntity);

        MatchResponse ToMatchResponse(MatchEntity matchEntity);

        TeamEntity ToTeamEntity(TeamViewModel model, string path, bool isNew);

        TeamViewModel ToTeamViewModel(TeamEntity teamEntity);

        TournamentEntity ToTournamentEntity(TournamentViewModel model, string path, bool isNew);

        TournamentViewModel ToTournamentViewModel(TournamentEntity tournamentEntity);

        Task<GroupEntity> ToGroupEntityAsync(GroupViewModel model, bool isNew);

        GroupViewModel ToGroupViewModel(GroupEntity groupEntity);

        Task<GroupDetailEntity> ToGroupDetailEntityAsync(GroupDetailViewModel model, bool isNew);

        GroupDetailViewModel ToGroupDetailViewModel(GroupDetailEntity groupDetailEntity);

        Task<MatchEntity> ToMatchEntityAsync(MatchViewModel model, bool isNew);

        MatchViewModel ToMatchViewModel(MatchEntity matchEntity);

        TournamentResponse ToTournamentResponse(TournamentEntity tournamentEntity);

        List<TournamentResponse> ToTournamentResponse(List<TournamentEntity> tournamentEntities);
    }
}
