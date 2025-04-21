using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.DailyNutritionDetailInterfaces
{
    public interface IDailyNutritionDetailGetByUserIdRepository
    {
        Task<List<GetLatestDailyNutritionDetailsResult>> GetLatestDetailsByUserIdAsync(int appUserId);
    }
}
