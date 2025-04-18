using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyMacroCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler
{
    public class CreateDailyMacroCommandHandler
    {
        private readonly IRepository<DailyMacro> _repository;

        public CreateDailyMacroCommandHandler(IRepository<DailyMacro> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDailyMacroCommand command)
        {
            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            await _repository.CreateAsync(new DailyMacro
            {
                AppUserId = command.AppUserId,
                Calories = command.Calories,
                Carbohydrates = command.Carbohydrates,
                Date = dateOnly,
                Fats = command.Fats,
                Proteins = command.Proteins,
            });
        }
    }
}
