using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyMacroQueries
{
    public class GetLatestDailyMacroByUserIdQuery
    {
        public int AppUserId { get; set; }
        public GetLatestDailyMacroByUserIdQuery(int appUserId) => AppUserId = appUserId;
    }
}
