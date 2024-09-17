using GYM_Nurition.Domain.Dtos;
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
    public class Top10UsageNutritionRepository : ITop10UsageNutritionRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public Top10UsageNutritionRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<DailyNutritionDetails>> GetAllNutritionDetailsAsync()
        {
            return await _context.DailyNutritionDetails.ToListAsync();
        }

    }
}
