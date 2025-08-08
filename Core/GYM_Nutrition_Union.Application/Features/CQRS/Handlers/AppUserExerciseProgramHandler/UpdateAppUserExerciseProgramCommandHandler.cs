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

            decimal volumeConfficient = 0.0015M;
            decimal genderFactor = userDetail.sex == false ? 0.90M : 1.00M;
            decimal bodyWeight = userDetail.Weight;
            decimal baseMET = exerciseDetail.BaseMET;
            decimal secondsPerRep = 3.0M;
            decimal restBetweenSets = 60.0M;
            decimal activeTimePerSet = command.ExerciseRepeat * secondsPerRep;
            decimal totalTimeSeconds = command.ExerciseSet * (activeTimePerSet + restBetweenSets);
            //decimal duration = command.ExerciseSet * (command.ExerciseRepeat * 0.5M);
            decimal aerobicCalories = (baseMET * 3.5M * bodyWeight / 200) * (totalTimeSeconds / 60);
            decimal resistanceVolume = command.ExerciseWeight * command.ExerciseRepeat * command.ExerciseSet;
            decimal resistanceCalories = volumeConfficient * resistanceVolume;

            decimal totalCalories = genderFactor * (aerobicCalories + resistanceCalories);

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
			values.ExerciseTotalBurnedKcal = (int)totalCalories;
			values.DayNo = command.DayNo;
			values.Date = dateOnly;
			await _repository.UpdateAsync(values);
		}
	}
}
