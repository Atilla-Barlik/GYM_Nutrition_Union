using GYM_Nurition.Domain.Dtos.AppUserExerciseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces
{
    public interface IAppUserExerciseStatisticsRepository
    {
        Task<List<AppUserExerciseStatisticsDto>> GetUserExerciseStatisticsAsync(int appUserId);
    }
}
