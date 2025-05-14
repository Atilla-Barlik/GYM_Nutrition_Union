using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
    public class GetClosedDailyNutritionByUserQueryHandler
    {
        private readonly IDailyNutritionGetClosedByUserRepository _repo;
        public GetClosedDailyNutritionByUserQueryHandler(IDailyNutritionGetClosedByUserRepository repo)
            => _repo = repo;

        public async Task<List<GetClosedDailyNutritionByUserIdQueryResult>> Handle(GetClosedDailyNutritionByUserQuery query)
        {
            return await _repo.GetClosedByUserAsync(query.AppUserId);
        }
    }
}
