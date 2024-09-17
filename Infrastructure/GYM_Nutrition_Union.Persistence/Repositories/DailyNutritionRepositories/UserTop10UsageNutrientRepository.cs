using GYM_Nurition.Domain.Entities;
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
    public class UserTop10UsageNutrientRepository : IUserTop10UsageNutrientRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public UserTop10UsageNutrientRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<DailyNutritionDetails>> GetMostUsedNutrients(int appUserId)
        {
            return await _context.DailyNutritionDetails
                .Where(dnd => dnd.DailyNutrition.AppUserId == appUserId)
                .GroupBy(dnd => dnd.NutrientName)
                .OrderByDescending(g => g.Count())  // En çok tekrar eden besini buluyor
                .Select(g => g.FirstOrDefault())  // İsimlere göre filtrelenmiş ilk sonuçları al
                .Take(10) // En çok kullanılan 10 besin
                .ToListAsync();
        }
    }
}
