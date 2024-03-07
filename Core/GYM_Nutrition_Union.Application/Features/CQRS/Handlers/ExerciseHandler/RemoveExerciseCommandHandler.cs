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
	public class RemoveExerciseCommandHandler
	{
		private readonly IRepository<Exercise> _repository;

		public RemoveExerciseCommandHandler(IRepository<Exercise> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveExerciseCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
