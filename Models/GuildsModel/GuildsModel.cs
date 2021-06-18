using System.Collections.Generic;
using MatchmakerBotAPI.Core.Models.GuildsModel;

namespace MatchmakerBotAPI.Core.Models {
    public class Guilds {
        public string channelID { get; set; }

        public Dictionary<string, int>[] channels { get; set; }

        public int losses { get; set; }

        public int mmr { get; set; }

        public Teams[] team { get; set; }
    }
}