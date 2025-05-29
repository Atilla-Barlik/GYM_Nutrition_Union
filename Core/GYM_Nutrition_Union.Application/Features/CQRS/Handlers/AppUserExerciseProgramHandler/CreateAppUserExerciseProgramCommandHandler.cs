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
	public class CreateAppUserExerciseProgramCommandHandler
	{
		private readonly IRepository<AppUserExerciseProgram> _repository;
        private readonly IAppUserDetailRepository _appUserDetailRepository;
        private readonly IExerciseDetailRepository _exerciseDetailRepository;

        public CreateAppUserExerciseProgramCommandHandler(IRepository<AppUserExerciseProgram> repository, IAppUserDetailRepository appUserDetailRepository,
        IExerciseDetailRepository exerciseDetailRepository)
		{
			_repository = repository;
            _appUserDetailRepository = appUserDetailRepository;
            _exerciseDetailRepository = exerciseDetailRepository;
        }

		public async Task Handle(CreateAppUserExerciseProgramCommand command)
		{
            // Kullanıcı detaylarını al (Weight)
            var userDetail = await _appUserDetailRepository.GetByUserId(command.AppUserId);
            if (userDetail == null)
            {
                throw new Exception("User not found.");
            }

            // Egzersiz detaylarını al (BaseMET)
            var exerciseDetail = await _exerciseDetailRepository.GetById(command.ExerciseDetailId);
            if (exerciseDetail == null)
            {
                throw new Exception("Exercise not found.");
            }

            // Değişkenleri ata
            decimal bodyWeight = userDetail.Weight;
            decimal baseMET = exerciseDetail.BaseMET;
            decimal totalWeightLifted = command.ExerciseWeight * command.ExerciseRepeat * command.ExerciseSet;

            // Dinamik MET Hesapla
            decimal dynamicMET = baseMET + ((decimal)Math.Pow((double)totalWeightLifted, 0.6) /
                               (decimal)Math.Pow((double)bodyWeight, 0.5) * 0.08M);

            // Egzersiz süresi tahmini (set başına 30 saniye)
            decimal exerciseDuration = command.ExerciseSet * (command.ExerciseRepeat * 0.5M);

            // Yakılan kaloriyi hesapla
            decimal burnedCalories = dynamicMET * bodyWeight * 0.0175M * exerciseDuration;

            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            await _repository.CreateAsync(new AppUserExerciseProgram
			{
				AppUserId = command.AppUserId,
				ExerciseDetailId = command.ExerciseDetailId,
				ExerciseRepeat = command.ExerciseRepeat,
				ExerciseSet = command.ExerciseSet,
				ExerciseWeight = command.ExerciseWeight,
                ExerciseDone = command.ExerciseDone,
				ExerciseTotalBurnedKcal = (int)burnedCalories,
				DayNo = command.DayNo,
				Date = dateOnly
			});
		}
	}
}
