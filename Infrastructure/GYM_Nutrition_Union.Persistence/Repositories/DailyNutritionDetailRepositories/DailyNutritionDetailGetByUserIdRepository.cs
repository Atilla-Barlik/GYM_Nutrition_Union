using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionDetailResults;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionDetailInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.DailyNutritionDetailRepositories
{
    public class DailyNutritionDetailGetByUserIdRepository : IDailyNutritionDetailGetByUserIdRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public DailyNutritionDetailGetByUserIdRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<GetLatestDailyNutritionDetailsResult>> GetLatestDetailsByUserIdAsync(int appUserId)
        {
            var latestNutrition = await _context.DailyNutrition
                .Where(x => x.AppUserId == appUserId)
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync();

            if (latestNutrition == null)
                return new List<GetLatestDailyNutritionDetailsResult>();

            return await _context.DailyNutritionDetails
                .Where(x => x.DailyNutritionId == latestNutrition.DailyNutritionID)
                .Select(x => new GetLatestDailyNutritionDetailsResult
                {
                    DailyNutritionDetailsId = x.DailyNutritionDetailsId,
                    NutrientName = x.NutrientName,
                    NutrientImage = x.NutrientImage,
                    NutrientKcal = x.NutrientKcal,
                    NutrientCarbohydrate = x.NutrientCarbohydrate,
                    NutrientProtein = x.NutrientProtein,
                    NutrientFat = x.NutrientFat,
                    DailyNutritionId = x.DailyNutritionId,
                    DailyMealTime = x.DailyMealTime
                })
                .ToListAsync();
        }

    }
}
