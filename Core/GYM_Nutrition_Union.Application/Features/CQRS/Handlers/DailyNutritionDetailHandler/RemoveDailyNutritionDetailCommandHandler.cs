using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler
{
	public class RemoveDailyNutritionDetailCommandHandler
	{
		private readonly IRepository<DailyNutritionDetails> _repository;

		public RemoveDailyNutritionDetailCommandHandler(IRepository<DailyNutritionDetails> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveDailyNutritionDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
