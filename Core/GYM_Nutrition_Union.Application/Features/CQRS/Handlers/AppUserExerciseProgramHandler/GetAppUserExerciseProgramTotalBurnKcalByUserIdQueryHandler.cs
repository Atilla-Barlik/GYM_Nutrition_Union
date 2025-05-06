using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserExerciseProgramQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserExerciseProgramResults;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler
{
    public class GetAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler
    {
        private readonly IAppUserExerciseProgramRespository _repo;
        public GetAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler(IAppUserExerciseProgramRespository repo)
        {
            _repo = repo;
        }
        public async Task<List<GetAppUserExerciseProgramTotalBurnKcalQueryResult>> Handle(GetAppUserExerciseProgramTotalBurnKcalQuery q)
        {
            return await _repo.GetDailyBurnSummaryAsync(q.AppUserId);
        }
    }
}
