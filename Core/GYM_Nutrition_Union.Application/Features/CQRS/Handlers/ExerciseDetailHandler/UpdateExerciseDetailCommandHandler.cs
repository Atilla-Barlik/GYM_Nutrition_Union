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
	public class UpdateExerciseDetailCommandHandler
	{
		private readonly IRepository<ExerciseDetail> _repository;

		public UpdateExerciseDetailCommandHandler(IRepository<ExerciseDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateExerciseDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.ExerciseDetailId);
			values.Name = command.Name;
			values.ExerciseDetailId = command.ExerciseDetailId;
			values.ExerciseId = command.ExerciseId;
			values.AverageKcal = command.AverageKcal;
			values.Difficulty = command.Difficulty;
			values.Equipment = command.Equipment;
			values.Description1 = command.Description1;
			values.Description2 = command.Description2;
			values.Description3 = command.Description3;
			values.Description4 = command.Description4;
			values.Gif1 = command.Gif1;
			values.Gif2 = command.Gif2;
			values.Gif3 = command.Gif3;
			await _repository.UpdateAsync(values);
		}
	}
}
