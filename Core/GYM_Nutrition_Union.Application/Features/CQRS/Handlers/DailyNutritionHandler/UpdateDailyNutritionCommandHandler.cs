using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
	public class UpdateDailyNutritionCommandHandler
	{
		private readonly IRepository<DailyNutrition> _repository;

		public UpdateDailyNutritionCommandHandler(IRepository<DailyNutrition> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateDailyNutritionCommand command)
		{
			var values = await _repository.GetByIdAsync(command.DailyNutritionID);
			values.DailyNutritionID = command.DailyNutritionID;
			values.AppUserId = command.AppUserId;
			values.Date = command.Date;
			values.DailyNutritionTotalKcal = command.DailyNutritionTotalKcal;
			values.DailyNutritionTotalCarbohydrate = command.DailyNutritionTotalCarbohydrate;
			values.DailyNutritionTotalFat = command.DailyNutritionTotalFat;
			values.DailyNutritionTotalProtein = command.DailyNutritionTotalProtein;
			await _repository.UpdateAsync(values);
		}
	}
}
