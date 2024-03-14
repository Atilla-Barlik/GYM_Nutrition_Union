using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_NutritionDetails_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler
{
	public class CreateDailyNutritionDetailCommandHandler
	{
		private readonly IRepository<DailyNutritionDetails> _repository;

		public CreateDailyNutritionDetailCommandHandler(IRepository<DailyNutritionDetails> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDailyNutritionDetailCommand command)
		{
			await _repository.CreateAsync(new DailyNutritionDetails
			{
				DailyNutritionId = command.DailyNutritionId,
				NutrientName = command.NutrientName,
				NutrientImage = command.NutrientImage,
				NutrientKcal = command.NutrientKcal,
				NutrientCarbohydrate = command.NutrientCarbohydrate,
				NutrientProtein	= command.NutrientProtein,
				NutrientFat = command.NutrientFat
			});
		}
	}
}
