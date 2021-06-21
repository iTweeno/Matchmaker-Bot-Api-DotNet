using System.Collections.Generic;

namespace MatchmakerBotAPI.Core.Models.PageModel
{
    public class PageModel<T>
    {
        public int total { get; set; }

        public List<T> items { get; set; }

        public PageModel(int total, List<T> list) {
            this.items = list;
            this.total = total;
        }
    }
}