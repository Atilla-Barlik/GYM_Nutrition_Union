using GYM_Nurition.Domain.Dtos.AppUserExerciseDtos;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.AppUserExerciseStatisticsRepositories
{
    public class AppUserExerciseStatisticsRepository : IAppUserExerciseStatisticsRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public AppUserExerciseStatisticsRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<List<AppUserExerciseStatisticsDto>> GetUserExerciseStatisticsAsync(int appUserId)
        {
            return await _context.AppUsersExerciseProgram
                .Where(e => e.AppUserId == appUserId)
                .OrderBy(e => e.Date)
                .Select(e => new AppUserExerciseStatisticsDto
                {
                    ExerciseId = e.ExerciseDetailId,  // Kullanıcının yaptığı egzersizlerin ID'si
                    ExerciseName = e.exerciseDetail.Name,  // Egzersiz ismi
                    Date = e.Date,
                    ExerciseRepeat = e.ExerciseRepeat,
                    ExerciseSet = e.ExerciseSet,
                    ExerciseWeight = e.ExerciseWeight,
                    ExerciseTotalBurnedKcal = e.ExerciseTotalBurnedKcal
                })
                .ToListAsync();
        }
    }
}
