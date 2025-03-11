using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.NutrientInterfaces
{
    public interface INutrientRepository
    {
        Task<List<Nutrient>> GetNutrientByNameAsync(string name);
    }
}
