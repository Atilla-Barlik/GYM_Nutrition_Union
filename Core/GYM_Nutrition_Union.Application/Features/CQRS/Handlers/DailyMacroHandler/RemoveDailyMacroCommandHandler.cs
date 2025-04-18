using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyMacroCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler
{
    public class RemoveDailyMacroCommandHandler
    {
        private readonly IRepository<DailyMacro> _repository;

        public RemoveDailyMacroCommandHandler(IRepository<DailyMacro> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveDailyMacroCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
