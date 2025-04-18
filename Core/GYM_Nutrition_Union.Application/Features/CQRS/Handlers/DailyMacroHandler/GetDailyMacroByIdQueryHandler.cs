using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyMacroQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyMacroResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionDetailResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler
{
    public class GetDailyMacroByIdQueryHandler
    {
        private readonly IRepository<DailyMacro> _repository;

        public GetDailyMacroByIdQueryHandler(IRepository<DailyMacro> repository)
        {
            _repository = repository;
        }

        public async Task<GetDailyMacroByIdQueryResult> Handle(GetDailyMacroByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetDailyMacroByIdQueryResult
            {
                DailyMacroId = values.DailyMacroId,
                AppUserId = values.AppUserId,
                Calories = values.Calories,
                Carbohydrates = values.Carbohydrates,
                Proteins = values.Proteins,
                Fats = values.Fats,
                Date = values.Date

            };
        }
    }
}
