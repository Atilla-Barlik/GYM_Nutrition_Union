using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.NutrientCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientHandler
{
    public class RemoveNutrientCommandHandler
    {
        private readonly IRepository<Nutrient> _repository;

        public RemoveNutrientCommandHandler(IRepository<Nutrient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveNutrientCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
