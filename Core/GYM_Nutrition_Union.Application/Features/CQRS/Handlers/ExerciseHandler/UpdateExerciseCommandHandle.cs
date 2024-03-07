using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler
{
	public class UpdateExerciseCommandHandle
	{
		private readonly IRepository<Exercise> _repository;

		public UpdateExerciseCommandHandle(IRepository<Exercise> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateExerciseCommand command)
		{
			var values = await _repository.GetByIdAsync(command.ExerciseId);
			values.ExerciseName = command.ExerciseName;
			values.ExerciseId = command.ExerciseId;
			await _repository.UpdateAsync(values);
		}
	}
}
