using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
    public class CloseDailyNutritionCommandHandler
    {
        private readonly IDailyNutritionTotalsRepository _repository;
        public CloseDailyNutritionCommandHandler(IDailyNutritionTotalsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Komutu işleyerek toplamları parent kayda yazar ve kapatır
        /// </summary>
        public async Task Handle(CloseDailyNutritionCommand command)
        {
            await _repository.AggregateAndCloseAsync(command.DailyNutritionId);
        }
    }
}
