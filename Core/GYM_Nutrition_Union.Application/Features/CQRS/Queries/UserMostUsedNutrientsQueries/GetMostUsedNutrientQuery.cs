using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.UserMostUsedNutrientsQueries
{
    public class GetMostUsedNutrientQuery
    {
        public int AppUserId { get; set; }

        public GetMostUsedNutrientQuery(int appUserId)
        {
            AppUserId = appUserId;
        }
    }
}
