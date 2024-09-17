using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.UserMostUsedNutrientsQueries;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
    public class GetUserMostUsedNutrientsQueryHandler
    {
        private readonly IUserTop10UsageNutrientRepository _userTop10UsageNutrientRepository;

        public GetUserMostUsedNutrientsQueryHandler(IUserTop10UsageNutrientRepository userTop10UsageNutrientRepository)
        {
            _userTop10UsageNutrientRepository = userTop10UsageNutrientRepository;
        }

        public async Task<List<DailyNutritionDetails>> Handle(GetMostUsedNutrientQuery query)
        {
            return await _userTop10UsageNutrientRepository.GetMostUsedNutrients(query.AppUserId);
        }
    }
}
