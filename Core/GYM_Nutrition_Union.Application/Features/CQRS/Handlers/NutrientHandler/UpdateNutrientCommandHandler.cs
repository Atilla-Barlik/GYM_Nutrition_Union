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
    public class UpdateNutrientCommandHandler
    {
        private readonly IRepository<Nutrient> _repository;

        public UpdateNutrientCommandHandler(IRepository<Nutrient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateNutrientCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Name = command.Name;
            values.image = command.image;
            values.kcal = command.kcal;
            values.carbonhydrate = command.carbonhydrate;
            values.protein = command.protein;
            values.fat = command.fat;
            values.sugar = command.sugar;
            values.fiber = command.fiber;
            values.cholestrol = command.cholestrol;
            values.sodium = command.sodium;
            values.potassium = command.potassium;
            values.calcium = command.calcium;
            values.vitamin_A = command.vitamin_A;
            values.vitamin_C = command.vitamin_C;
            values.iron = command.iron;
            await _repository.UpdateAsync(values);
        }
    }
}
