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
    public class CreateNutrientCommandHandler
    {
        private readonly IRepository<Nutrient> _repository;

        public CreateNutrientCommandHandler(IRepository<Nutrient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateNutrientCommand command)
        {
            await _repository.CreateAsync(new Nutrient
            {
                Name = command.Name,
                image = command.image,
                kcal = command.kcal,
                carbonhydrate = command.carbonhydrate,
                protein = command.protein,
                fat = command.fat,
                sugar = command.sugar,
                fiber = command.fiber,
                cholestrol = command.cholestrol,
                sodium = command.sodium,
                potassium = command.potassium,
                calcium = command.calcium,
                vitamin_A = command.vitamin_A,
                vitamin_C = command.vitamin_C,
                iron = command.iron
            });
        }
    }
}
