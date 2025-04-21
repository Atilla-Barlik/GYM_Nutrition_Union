using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionDetailResults;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionDetailInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler
{
    public class GetLatestNutritionDetailsByUserIdQueryHandler
    {
        private readonly IDailyNutritionDetailGetByUserIdRepository _repository;

        public GetLatestNutritionDetailsByUserIdQueryHandler(IDailyNutritionDetailGetByUserIdRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLatestDailyNutritionDetailsResult>> Handle(GetLatestNutritionDetailsByUserIdQuery query)
        {
            return await _repository.GetLatestDetailsByUserIdAsync(query.AppUserId);
        }
    }
}
