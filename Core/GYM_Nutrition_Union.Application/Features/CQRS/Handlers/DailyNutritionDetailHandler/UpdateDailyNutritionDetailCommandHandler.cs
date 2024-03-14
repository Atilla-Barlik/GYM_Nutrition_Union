using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler
{
	public class UpdateDailyNutritionDetailCommandHandler
	{
		private readonly IRepository<DailyNutritionDetails> _repository;

		public UpdateDailyNutritionDetailCommandHandler(IRepository<DailyNutritionDetails> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateDailyNutritionDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.DailyNutritionDetailsId);
			values.DailyNutritionDetailsId = command.DailyNutritionDetailsId;
			values.DailyNutritionId = command.DailyNutritionId;
			values.NutrientName = command.NutrientName;
			values.NutrientImage = command.NutrientImage;
			values.NutrientKcal = command.NutrientKcal;
			values.NutrientCarbohydrate = command.NutrientCarbohydrate;
			values.NutrientFat = command.NutrientFat;
			values.NutrientProtein = command.NutrientProtein;
			await _repository.UpdateAsync(values);
		}
	}
}
