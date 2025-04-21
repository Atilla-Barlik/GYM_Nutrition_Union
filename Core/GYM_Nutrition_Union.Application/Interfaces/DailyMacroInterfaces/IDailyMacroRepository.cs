using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyMacroResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.DailyMacroInterfaces
{
    public interface IDailyMacroRepository
    {
        Task<GetDailyMacroByUserIdQueryResult> GetLatestMacroByUserIdAsync(int appUserId);
    }
}
