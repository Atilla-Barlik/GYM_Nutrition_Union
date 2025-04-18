using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyMacroCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler
{
    public class UpdateDailyMacroCommandHandler
    {
        private readonly IRepository<DailyMacro> _repository;

        public UpdateDailyMacroCommandHandler(IRepository<DailyMacro> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDailyMacroCommand command)
        {
            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            var values = await _repository.GetByIdAsync(command.DailyMacroId);
            values.DailyMacroId = command.DailyMacroId;
            values.AppUserId = command.AppUserId;
            values.Calories = command.Calories;
            values.Carbohydrates = command.Carbohydrates;
            values.Proteins = command.Proteins;
            values.Fats = command.Fats;
            values.Date = dateOnly;
            await _repository.UpdateAsync(values);
        }
    }
}
