using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.NutrientInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.NutrientRepositories
{
    public class NutrientRepository : INutrientRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public NutrientRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<Nutrient>> GetNutrientByNameAsync(string name)
        {
            return await _context.Nutrient.Where(n => n.Name.Contains(name)).ToListAsync();
        }
    }
}
