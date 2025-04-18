using GYM_Nurition.Domain.Entities;
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
    public class GetDailyMacroQueryHandler
    {
        private readonly IRepository<DailyMacro> _repository;

        public GetDailyMacroQueryHandler(IRepository<DailyMacro> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDailyMacroQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDailyMacroQueryResult
            {
                DailyMacroId = x.DailyMacroId,
                AppUserId = x.AppUserId,
                Calories = x.Calories,
                Carbohydrates = x.Carbohydrates,
                Proteins = x.Proteins,
                Fats = x.Fats,
                Date = x.Date
            }).ToList();
        }
    }
}
