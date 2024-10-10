using GYM_Nurition.Domain.Dtos.AppUserExerciseDtos;
using GYM_Nurition.Domain.ModelViews;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetAppUserProgramDetailsQueries;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramDetailsHandler
{
    public class GetAppUserExerciseProgramDetailsQueryHandler
    {
        private readonly IAppUserExerciseProgramRespository _repository;

        public GetAppUserExerciseProgramDetailsQueryHandler(IAppUserExerciseProgramRespository repository)
        {
            _repository = repository;
        }

        public async Task<List<CombinedExerciseDataDto>> Handle(GetAppUserExerciseProgramDetailsQuery query)
        {
            // Kullanıcıya ait egzersiz programlarını al
            var userExercises = await _repository.GetUserExerciseProgramsAsync(query.AppUserId);

            // ExerciseDetailId'lerini al
            var exerciseDetailIds = userExercises.Select(ue => ue.ExerciseDetailId).ToList();

            // ExerciseDetail verilerini al
            var exerciseDetails = await _repository.GetExerciseDetailsAsync(exerciseDetailIds);

            // Birleştirilmiş verileri oluştur
            var combinedData = userExercises.Select(ue => new CombinedExerciseDataDto
            {
                AppUserExerciseProgramId = ue.AppUserExerciseProgramId,
                ExerciseRepeat = ue.ExerciseRepeat,
                ExerciseSet = ue.ExerciseSet,
                ExerciseWeight = ue.ExerciseWeight,
                ExerciseTotalBurnedKcal = ue.ExerciseTotalBurnedKcal,
                AppUserId = ue.AppUserId,
                Date = ue.Date,
                DayNo = ue.DayNo,
                ExerciseDetailDto = exerciseDetails.FirstOrDefault(ed => ed.ExerciseDetailId == ue.ExerciseDetailId)
            }).ToList();

            return combinedData;
        }
    }
}
