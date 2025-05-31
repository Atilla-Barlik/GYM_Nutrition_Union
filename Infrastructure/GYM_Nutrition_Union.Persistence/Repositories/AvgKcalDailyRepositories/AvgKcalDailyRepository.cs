using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyAvgKcalResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyMacroResults;
using GYM_Nutrition_Union.Application.Interfaces.AvgKcalDailyInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.AvgKcalDailyRepositories
{
    public class AvgKcalDailyRepository : IAvgKcalDailyRepository
    {
        private readonly GYM_Nutrition_Context _context;
        public AvgKcalDailyRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }
        public async Task<List<GetAvgKcalDailyByUserIdQueryResult>> GetLatestAvgKcalDailyByUserIdAsync(int appUserId)
        {
            var x = await _context.AvgKcalDailyResults
               .Where(x => x.AppUserId == appUserId)
               .OrderByDescending(x => x.Date)
               .ThenByDescending(x => x.AvgKcalDailyResultsId)
               .FirstOrDefaultAsync();

            if (x == null) return new List<GetAvgKcalDailyByUserIdQueryResult>();

            return await _context.AvgKcalDailyResults.Select(a=> new GetAvgKcalDailyByUserIdQueryResult
            {
                AvgKcalDailyResultsId = a.AvgKcalDailyResultsId,
                BurnKcal = a.BurnKcal,
                DailyMacro = a.DailyMacro,
                DailyTakenKcal = a.DailyTakenKcal,
                ResultKcal = a.ResultKcal,
                Date = a.Date,
                AppUserId = a.AppUserId
            }).ToListAsync();
        }
    }
}
