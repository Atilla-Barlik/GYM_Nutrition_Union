using GYM_Nurition.Domain.Dtos.AppUserExerciseDtos;
using GYM_Nurition.Domain.Entities;
using GYM_Nurition.Domain.ModelViews;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.AppUserExerciseProgramRepositories
{
    public class AppUserExerciseProgramRespository : IAppUserExerciseProgramRespository
    {
        private readonly GYM_Nutrition_Context _context;

        public AppUserExerciseProgramRespository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<AppUserExerciseProgramDto>> GetUserExerciseProgramsAsync(int appUserId)
        {
            return await _context.AppUsersExerciseProgram
                .Where(a => a.AppUserId == appUserId).Select(s=>new AppUserExerciseProgramDto
                {
                    AppUserId = s.AppUserId,
                    ExerciseDetailId = s.ExerciseDetailId,
                    AppUserExerciseProgramId = s.AppUserExerciseProgramId,
                    Date = s.Date,
                    DayNo = s.DayNo,
                    ExerciseRepeat = s.ExerciseRepeat,
                    ExerciseSet = s.ExerciseSet,
                    ExerciseTotalBurnedKcal = s.ExerciseTotalBurnedKcal
                })
            .ToListAsync();
        }

        public async Task<List<ExerciseDetailDto>> GetExerciseDetailsAsync(List<int> exerciseDetailIds)
        {
            return await _context.ExerciseDetails
                .Where(ed => exerciseDetailIds.Contains(ed.ExerciseDetailId)).Select(s=>new ExerciseDetailDto
                {
                    ExerciseId = s.ExerciseId,
                    ExerciseDetailId = s.ExerciseDetailId,
                    Name = s.Name,
                    AverageKcal = s.AverageKcal,
                    Description1 = s.Description1,
                    Description2 = s.Description2,
                    Description3 = s.Description3,
                    Description4 = s.Description4,
                    Difficulty = s.Difficulty,
                    Equipment = s.Equipment,
                    Gif1 = s.Gif1,
                    Gif2 = s.Gif2,
                    Gif3 = s.Gif3,
                })
                .ToListAsync();
        }
    }
}
