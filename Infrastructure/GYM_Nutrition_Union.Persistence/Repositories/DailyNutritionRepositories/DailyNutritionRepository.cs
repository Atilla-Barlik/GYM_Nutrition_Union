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
    public class DailyNutritionRepository : IDailyNutritionRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public DailyNutritionRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<DailyNutrition> GetDailyNutritionByUserIdAndDateAsync(int userId)
        {
            DateTime dateTime = DateTime.Now;
            DateOnly date2 = DateOnly.FromDateTime(dateTime);
            return await _context.DailyNutrition
                                 .FirstOrDefaultAsync(dn => dn.AppUserId == userId && dn.Date == date2);
        }

        public async Task AddDailyNutritionAsync(DailyNutrition dailyNutrition)
        {
            await _context.DailyNutrition.AddAsync(dailyNutrition);
            await _context.SaveChangesAsync();
        }
    }
}
