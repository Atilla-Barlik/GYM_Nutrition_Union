using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserBodyDetailResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.NutrientResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientHandler
{
    public class GetNutrientQueryHandler
    {
        private readonly IRepository<Nutrient> _repository;

        public GetNutrientQueryHandler(IRepository<Nutrient> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetNutrientQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetNutrientQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                image = x.image,
                kcal = x.kcal,
                carbonhydrate = x.carbonhydrate,
                protein = x.protein,
                fat = x.fat,
                sugar = x.sugar,
                fiber = x.fiber,
                cholestrol = x.cholestrol,
                sodium = x.sodium,
                potassium = x.potassium,
                calcium = x.calcium,
                vitamin_A = x.vitamin_A,
                vitamin_C = x.vitamin_C,
                iron = x.iron,
            }).ToList();
        }
    }
}
