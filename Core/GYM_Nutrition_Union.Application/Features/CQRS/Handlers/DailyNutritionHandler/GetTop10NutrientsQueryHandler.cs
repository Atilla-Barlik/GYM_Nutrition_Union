using GYM_Nurition.Domain.Dtos;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
    public class GetTop10NutrientsQueryHandler
    {
        private readonly ITop10UsageNutritionRepository _nutritionRepository;

        public GetTop10NutrientsQueryHandler(ITop10UsageNutritionRepository nutritionRepository)
        {
            _nutritionRepository = nutritionRepository;
        }

        public async Task<List<totalUsageNutritionDto>> Handle()
        {
            var nutrientDetails = await _nutritionRepository.GetAllNutritionDetailsAsync();
            var mostUsedNutrients = nutrientDetails
           .GroupBy(n => n.NutrientName)
           .Select(group => new totalUsageNutritionDto
           {
               // Gruplardaki ilk besinin tüm özelliklerini alıyoruz
               DailyNutritionDetailsId = group.First().DailyNutritionDetailsId,
               NutrientName = group.Key,  // Besin ismi
               NutrientImage = group.First().NutrientImage,
               NutrientKcal = group.First().NutrientKcal,
               NutrientCarbohydrate = group.First().NutrientCarbohydrate,
               NutrientProtein = group.First().NutrientProtein,
               NutrientFat = group.First().NutrientFat,
               DailyNutritionId = group.First().DailyNutritionId,
               DailyMealTime = group.First().DailyMealTime,
               TotalUsageCount = group.Count()  // Kullanım sayısını hesaplıyoruz
           })
           .OrderByDescending(n => n.TotalUsageCount)  // Kullanım sayısına göre sırala
           .Take(10)  // En çok kullanılan 10 besini al
           .ToList();

            return mostUsedNutrients;
        }
    }
}
