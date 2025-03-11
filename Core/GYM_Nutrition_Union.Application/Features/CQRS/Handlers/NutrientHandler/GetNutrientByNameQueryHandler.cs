using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientQueries;
using GYM_Nutrition_Union.Application.Interfaces.NutrientInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientHandler
{
    public class GetNutrientByNameQueryHandler
    {
        private readonly INutrientRepository _nutrientRepository;

        public GetNutrientByNameQueryHandler(INutrientRepository nutrientRepository)
        {
            _nutrientRepository = nutrientRepository;
        }

        public async Task<List<Nutrient>> Handle(GetNutrientByNameQuery query)
        {
            return await _nutrientRepository.GetNutrientByNameAsync(query.Name);
        }
    }
}
