namespace MatchmakerBotAPI.Core.Models.MatchmakerUsersModel
{
    public class MatchmakerScore
    {
        public string channelId { get; set; }

        public int wins { get; set; }

        public int losses { get; set; }

        public int mmr { get; set; }
    }
}