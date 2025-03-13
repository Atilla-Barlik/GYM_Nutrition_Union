using GYM_Nurition.Domain.Dtos.AppUserExerciseDtos;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserExerciseProgramQueries;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramDetailsHandler
{
    public class GetUserExerciseStatisticsQueryHandler
    {
        private readonly IAppUserExerciseStatisticsRepository _repository;

        public GetUserExerciseStatisticsQueryHandler(IAppUserExerciseStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AppUserExerciseStatisticsDto>> Handle(GetUserExerciseStatisticsQuery query)
        {
            return await _repository.GetUserExerciseStatisticsAsync(query.AppUserId);
        }
    }
}
