using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Application.Interfaces.AppUserDetailInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseDetailInterfaces;
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
        private readonly IAppUserDetailRepository _appUserDetailRepository;
        private readonly IExerciseDetailRepository _exerciseDetailRepository;

        public UpdateAppUserExerciseProgramCommandHandler(IRepository<AppUserExerciseProgram> repository, IAppUserDetailRepository appUserDetailRepository,
        IExerciseDetailRepository exerciseDetailRepository)
		{
			_repository = repository;
            _appUserDetailRepository = appUserDetailRepository;
            _exerciseDetailRepository = exerciseDetailRepository;
        }

		public async Task Handle(UpdateAppUserExerciseProgramCommand command)
		{
            var a = await _repository.GetByIdAsync(command.AppUserExerciseProgramId);
            if (a == null)
            {
                throw new Exception("Exercise program not found");
            }

            var userDetail = await _appUserDetailRepository.GetByUserId(command.AppUserId);
            var exerciseDetail = await _exerciseDetailRepository.GetById(command.ExerciseDetailId);

            if (userDetail == null || exerciseDetail == null)
            {
                throw new Exception("User or Exercise not found");
            }

            decimal bodyWeight = userDetail.Weight;
            decimal baseMET = exerciseDetail.BaseMET;
            decimal totalWeightLifted = command.ExerciseWeight * command.ExerciseRepeat * command.ExerciseSet;

            decimal dynamicMET = baseMET + ((decimal)Math.Pow((double)totalWeightLifted, 0.6) /
                               (decimal)Math.Pow((double)bodyWeight, 0.5) * 0.08M);

            decimal exerciseDuration = command.ExerciseSet * (command.ExerciseRepeat * 0.5M);
            decimal burnedCalories = dynamicMET * bodyWeight * 0.0175M * exerciseDuration;

            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            var values = await _repository.GetByIdAsync(command.AppUserExerciseProgramId);
			values.AppUserExerciseProgramId = command.AppUserExerciseProgramId;
			values.AppUserId = command.AppUserId;
			values.ExerciseDetailId = command.ExerciseDetailId;
			values.ExerciseSet = command.ExerciseSet;
			values.ExerciseRepeat = command.ExerciseRepeat;
			values.ExerciseWeight = command.ExerciseWeight;
            values.ExerciseDone = command.ExerciseDone;
			values.ExerciseTotalBurnedKcal = (int)burnedCalories;
			values.DayNo = command.DayNo;
			values.Date = dateOnly;
			await _repository.UpdateAsync(values);
		}
	}
}
