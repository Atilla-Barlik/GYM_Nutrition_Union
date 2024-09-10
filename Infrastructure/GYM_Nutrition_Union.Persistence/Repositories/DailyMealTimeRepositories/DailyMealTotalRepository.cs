using GYM_Nurition.Domain.Dtos;
using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.DailyMealTimeInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.DailyMealTimeRepositories
{
    public class DailyMealTotalRepository : IDailyMealTotalsRespository
    {
        private readonly GYM_Nutrition_Context _context;

        public DailyMealTotalRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<NutritionSummaryDto>> GetNutritionSummary(int dailyNutritionId)
        {
            return await _context.DailyNutritionDetails
             .Where(d => d.DailyNutritionId == dailyNutritionId)
             .GroupBy(d => d.DailyMealTime)
             .Select(g => new NutritionSummaryDto
             {
                 DailyMealTime = g.Key,
                 TotalKcal = g.Sum(x => x.NutrientKcal),
                 TotalCarbohydrate = g.Sum(x => x.NutrientCarbohydrate),
                 TotalProtein = g.Sum(x => x.NutrientProtein),
                 TotalFat = g.Sum(x => x.NutrientFat)
             })
             .ToListAsync();
        }
    }
}
