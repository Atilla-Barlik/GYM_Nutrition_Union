using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetAvgKcalDailyQueries
{
    public class GetLatestAvgKcalDailyByUserIdQuery
    {
        public int AppUserId { get; set; }
        public GetLatestAvgKcalDailyByUserIdQuery(int appUserId) => AppUserId = appUserId;
    }
}
