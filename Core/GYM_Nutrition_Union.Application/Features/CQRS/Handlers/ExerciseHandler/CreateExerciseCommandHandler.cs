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
	public class CreateExerciseCommandHandler
	{
		private readonly IRepository<Exercise> _repository;

		public CreateExerciseCommandHandler(IRepository<Exercise> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateExerciseCommand command)
		{
			await _repository.CreateAsync(new Exercise
			{
				ExerciseName = command.ExerciseName,
				ExerciseImage = command.ExerciseImage
			});
		}
	}
}
