using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
	public class CreateDailyNutritionCommandHandler
	{
		private readonly IRepository<DailyNutrition> _repository;

		public CreateDailyNutritionCommandHandler(IRepository<DailyNutrition> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDailyNutritionCommand command)
		{
			DateTime dateTime = DateTime.Now;
			DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
			await _repository.CreateAsync(new DailyNutrition
			{
				AppUserId = command.AppUserId,
				DailyNutritionStatus = command.DailyNutritionStatus,
				DailyNutritionTotalCarbohydrate = command.DailyNutritionTotalCarbohydrate,
				DailyNutritionTotalProtein = command.DailyNutritionTotalProtein,
				DailyNutritionTotalFat = command.DailyNutritionTotalFat,
				DailyNutritionTotalKcal = command.DailyNutritionTotalKcal,
				Date = dateOnly
			});
		}
	}
}
