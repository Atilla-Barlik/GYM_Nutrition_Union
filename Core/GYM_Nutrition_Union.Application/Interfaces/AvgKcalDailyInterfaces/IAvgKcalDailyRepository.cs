using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyAvgKcalResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyMacroResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.AvgKcalDailyInterfaces
{
    public interface IAvgKcalDailyRepository
    {
        Task<List<GetAvgKcalDailyByUserIdQueryResult>> GetLatestAvgKcalDailyByUserIdAsync(int appUserId);
    }
}
