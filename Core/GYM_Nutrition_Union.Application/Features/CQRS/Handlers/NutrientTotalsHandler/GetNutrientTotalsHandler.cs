using GYM_Nurition.Domain.Dtos;
using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientTotalsQueries;
using GYM_Nutrition_Union.Application.Interfaces.DailyMealTimeInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientTotalsHandler
{
    public class GetNutrientTotalsHandler
    {
        private readonly IDailyMealTotalsRespository _dailyMealTotalsRespository;

        public GetNutrientTotalsHandler(IDailyMealTotalsRespository dailyMealTotalsRespository)
        {
            _dailyMealTotalsRespository = dailyMealTotalsRespository;
        }

        public async Task<List<NutritionSummaryDto>> Handle(GetNutrientTotalsQuery request, CancellationToken cancellationToken)
        {
            // Artık sadece AppUserId üzerinden çalışıyoruz
            var summary = await _dailyMealTotalsRespository.GetNutritionSummary(request.appUserId);

            return summary;
        }
    }
}
