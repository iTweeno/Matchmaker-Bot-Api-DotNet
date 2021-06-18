using System;

namespace MatchmakerBotAPI.Core.Models.OngoingGamesModel
{
    public class OngoingGames
    {
        public int queueSize { get; set; }

        public int gameId { get; set; }

        public string gamemode { get; set; }

        public DateTime date { get; set; }

        public string channelId { get; set; }

        public VoiceChannels[] voiceChannelIds { get; set; }

        public string team1 { get; set; } //change

        public string team2 { get; set; } //change 
    }
}