using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseDetailHandler
{
	public class RemoveExerciseDetailCommandHandler
	{
		private readonly IRepository<ExerciseDetail> _repository;

		public RemoveExerciseDetailCommandHandler(IRepository<ExerciseDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveExerciseDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
