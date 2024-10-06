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
	public class UpdateAppUserExerciseProgramCommandHandler
	{
		private readonly IRepository<AppUserExerciseProgram> _repository;

		public UpdateAppUserExerciseProgramCommandHandler(IRepository<AppUserExerciseProgram> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAppUserExerciseProgramCommand command)
		{
            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            var values = await _repository.GetByIdAsync(command.AppUserExerciseProgramId);
			values.AppUserExerciseProgramId = command.AppUserExerciseProgramId;
			values.AppUserId = command.AppUserId;
			values.ExerciseDetailId = command.ExerciseDetailId;
			values.ExerciseSet = command.ExerciseSet;
			values.ExerciseRepeat = command.ExerciseRepeat;
			values.ExerciseTotalBurnedKcal = command.ExerciseTotalBurnedKcal;
			values.DayNo = command.DayNo;
			values.Date = dateOnly;
			await _repository.UpdateAsync(values);
		}
	}
}
