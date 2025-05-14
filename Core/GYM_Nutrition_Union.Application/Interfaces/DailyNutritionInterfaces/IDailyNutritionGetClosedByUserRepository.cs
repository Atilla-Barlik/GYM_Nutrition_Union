using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces
{
    public interface IDailyNutritionGetClosedByUserRepository
    {
        Task<List<GetClosedDailyNutritionByUserIdQueryResult>> GetClosedByUserAsync(int appUserId);
    }
}
