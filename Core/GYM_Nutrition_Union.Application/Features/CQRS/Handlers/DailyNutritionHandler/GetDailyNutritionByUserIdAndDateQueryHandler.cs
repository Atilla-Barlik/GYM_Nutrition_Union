using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
    public class GetDailyNutritionByUserIdAndDateQueryHandler
    {
        public class GetDailyNutritionByUserIdAndDateQuery : IRequest<DailyNutrition>
        {
            public int AppUserId { get; set; }
            public DateTime Date { get; set; }
        }
        private readonly IDailyNutritionRepository _dailyNutritionRepository;

        public GetDailyNutritionByUserIdAndDateQueryHandler(IDailyNutritionRepository dailyNutritionRepository)
        {
            _dailyNutritionRepository = dailyNutritionRepository;
        }

        public async Task<DailyNutrition> Handle(int userId, DateTime date)
        {
            return await _dailyNutritionRepository.GetDailyNutritionByUserIdAndDateAsync(userId, date);
        }
    }
}
