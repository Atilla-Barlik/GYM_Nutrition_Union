using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.DailyNutritionRepositories
{
    public class DailyNutritionGetClosedByUserRepository : IDailyNutritionGetClosedByUserRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public DailyNutritionGetClosedByUserRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<GetClosedDailyNutritionByUserIdQueryResult>> GetClosedByUserAsync(int appUserId)
        {
            return await _context.DailyNutrition
                .Where(x => x.AppUserId == appUserId && x.DailyNutritionStatus == false)
                .OrderBy(x => x.Date)
                .ThenBy(x => x.DailyNutritionID)
                .Select(x => new GetClosedDailyNutritionByUserIdQueryResult
                {
                    DailyNutritionID = x.DailyNutritionID,
                    DailyNutritionStatus = x.DailyNutritionStatus,
                    DailyNutritionTotalKcal = x.DailyNutritionTotalKcal,
                    DailyNutritionTotalCarbohydrate = x.DailyNutritionTotalCarbohydrate,
                    DailyNutritionTotalProtein = x.DailyNutritionTotalProtein,
                    DailyNutritionTotalFat = x.DailyNutritionTotalFat,
                    Date = x.Date,
                    AppUserId = x.AppUserId
                })
                .ToListAsync();
        }
    }
}
