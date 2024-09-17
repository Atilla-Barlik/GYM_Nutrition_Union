using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetDailyNutritionQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.NutrientResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientHandler
{
    public class GetNutrientByIdQueryHandler
    {
        private readonly IRepository<Nutrient> _repository;

        public GetNutrientByIdQueryHandler(IRepository<Nutrient> repository)
        {
            _repository = repository;
        }

        public async Task<GetNutrientByIdQueryResult> Handle(GetNutrientByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetNutrientByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                kcal = values.kcal,
                carbonhydrate = values.carbonhydrate,
                protein = values.protein,
                fat = values.fat,
                sugar = values.sugar,
                fiber = values.fiber,
                cholestrol = values.cholestrol,
                sodium = values.sodium,
                potassium = values.potassium,
                calcium = values.calcium,
                vitamin_A = values.vitamin_A,
                vitamin_C = values.vitamin_C,
                iron = values.iron,
            };
        }
    }
}
