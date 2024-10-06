using GYM_Nurition.Domain.Dtos.AppUserExerciseDtos;
using GYM_Nurition.Domain.Entities;
using GYM_Nurition.Domain.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces
{
    public interface IAppUserExerciseProgramRespository
    {
        Task<List<AppUserExerciseProgramDto>> GetUserExerciseProgramsAsync(int appUserId);
        Task<List<ExerciseDetailDto>> GetExerciseDetailsAsync(List<int> exerciseDetailIds);
    }
}
