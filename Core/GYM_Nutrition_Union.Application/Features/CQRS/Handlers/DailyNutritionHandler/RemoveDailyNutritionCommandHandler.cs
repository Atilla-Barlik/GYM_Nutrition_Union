using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
	public class RemoveDailyNutritionCommandHandler
	{
		private readonly IRepository<DailyNutrition> _repository;

		public RemoveDailyNutritionCommandHandler(IRepository<DailyNutrition> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveDailyNutritionCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
