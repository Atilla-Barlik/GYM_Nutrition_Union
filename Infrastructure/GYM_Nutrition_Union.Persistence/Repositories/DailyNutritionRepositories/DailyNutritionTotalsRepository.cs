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
    public class DailyNutritionTotalsRepository : IDailyNutritionTotalsRepository
    {
        private readonly GYM_Nutrition_Context _context;
        public DailyNutritionTotalsRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task AggregateAndCloseAsync(int dailyNutritionId)
        {
            // Parent kaydı al
            var parent = await _context.DailyNutrition
                .FirstOrDefaultAsync(d => d.DailyNutritionID == dailyNutritionId);
            if (parent == null)
                throw new KeyNotFoundException($"DailyNutrition {dailyNutritionId} bulunamadı.");

            // Detaylardan toplamları hesapla
            var sums = await _context.DailyNutritionDetails
                .Where(d => d.DailyNutritionId == dailyNutritionId)
                .GroupBy(d => d.DailyNutritionId)
                .Select(g => new
                {
                    TotalKcal = g.Sum(x => x.NutrientKcal),
                    TotalCarb = g.Sum(x => x.NutrientCarbohydrate),
                    TotalProt = g.Sum(x => x.NutrientProtein),
                    TotalFat = g.Sum(x => x.NutrientFat)
                })
                .FirstOrDefaultAsync();

            // Parent güncelle
            parent.DailyNutritionTotalKcal = sums?.TotalKcal ?? 0;
            parent.DailyNutritionTotalCarbohydrate = sums?.TotalCarb ?? 0;
            parent.DailyNutritionTotalProtein = sums?.TotalProt ?? 0;
            parent.DailyNutritionTotalFat = sums?.TotalFat ?? 0;
            parent.DailyNutritionStatus = false;

            await _context.SaveChangesAsync();
        }
    }
}
