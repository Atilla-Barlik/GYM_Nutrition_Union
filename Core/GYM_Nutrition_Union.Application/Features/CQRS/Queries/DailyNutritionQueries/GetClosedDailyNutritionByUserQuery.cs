using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionQueries
{
    public class GetClosedDailyNutritionByUserQuery
    {
        public int AppUserId { get; }
        public GetClosedDailyNutritionByUserQuery(int appUserId)
            => AppUserId = appUserId;
    }
}
