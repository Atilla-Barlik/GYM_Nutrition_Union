using GYM_Nurition.Domain.Dtos;
using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces
{
    public interface ITop10UsageNutritionRepository
    {
        Task<List<DailyNutritionDetails>> GetAllNutritionDetailsAsync();
    }
}
