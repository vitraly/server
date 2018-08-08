using System.Collections.Generic;

namespace API.Models
{
    public class NewsModel
    {
        public int PositionId { get; } = 1;

        public List<HeadlineModel> Headlines { get; set; }
    }
}
