using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler
{
	public class CreateAppUserExerciseProgramCommandHandler
	{
		private readonly IRepository<AppUserExerciseProgram> _repository;

		public CreateAppUserExerciseProgramCommandHandler(IRepository<AppUserExerciseProgram> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserExerciseProgramCommand command)
		{
            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            await _repository.CreateAsync(new AppUserExerciseProgram
			{
				AppUserId = command.AppUserId,
				ExerciseDetailId = command.ExerciseDetailId,
				ExerciseRepeat = command.ExerciseRepeat,
				ExerciseSet = command.ExerciseSet,
				ExerciseTotalBurnedKcal = command.ExerciseTotalBurnedKcal,
				DayNo = command.DayNo,
				Date = dateOnly
			});
		}
	}
}
