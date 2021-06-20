using System;
using MatchmakerBotAPI.Core.Models.Teams;

namespace MatchmakerBotAPI.Core.Models.OngoingGames
{
    public class OngoingGamesModel
    {
        public int queueSize { get; set; }

        public int gameId { get; set; }

        public string gamemode { get; set; }

        public DateTime date { get; set; }

        public string channelId { get; set; }

        public VoiceChannels[] voiceChannelIds { get; set; }

        public TeamsModel team1 { get; set; }

        public TeamsModel team2 { get; set; }
    }
}