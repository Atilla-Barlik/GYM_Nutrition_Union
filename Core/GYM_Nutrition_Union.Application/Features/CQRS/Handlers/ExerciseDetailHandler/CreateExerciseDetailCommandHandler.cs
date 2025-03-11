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
	public class CreateExerciseDetailCommandHandler
	{
		private readonly IRepository<ExerciseDetail> _repository;

		public CreateExerciseDetailCommandHandler(IRepository<ExerciseDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateExerciseDetailCommand command)
		{
			await _repository.CreateAsync(new ExerciseDetail
			{
				ExerciseId = command.ExerciseId,
				Name = command.Name,
				AverageKcal = command.AverageKcal,
				Description1 = command.Description1,
				Description2 = command.Description2,
				Description3 = command.Description3,
				Description4 = command.Description4,
				Difficulty = command.Difficulty,
				Equipment = command.Equipment,
				Gif1 = command.Gif1,
				Gif2 = command.Gif2,
				Gif3 = command.Gif3,
				BaseMET = command.BaseMET
			});
		}
	}
}
