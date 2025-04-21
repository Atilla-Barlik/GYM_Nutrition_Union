using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyMacroResults;
using GYM_Nutrition_Union.Application.Interfaces.DailyMacroInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.DailyMacroRepositories
{
    public class DailyMacroRepository : IDailyMacroRepository
    {
        private readonly GYM_Nutrition_Context _context;
        public DailyMacroRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }
        public async Task<GetDailyMacroByUserIdQueryResult> GetLatestMacroByUserIdAsync(int appUserId)
        {
            var latest = await _context.DailyMacro
               .Where(x => x.AppUserId == appUserId)
               .OrderByDescending(x => x.Date)
               .ThenByDescending(x => x.DailyMacroId)
               .FirstOrDefaultAsync();

            if (latest == null) return null;

            return new GetDailyMacroByUserIdQueryResult
            {
                DailyMacroId = latest.DailyMacroId,
                Calories = latest.Calories,
                Proteins = latest.Proteins,
                Carbohydrates = latest.Carbohydrates,
                Fats = latest.Fats,
                Date = latest.Date,
                AppUserId = latest.AppUserId
            };
        }
    }
}
