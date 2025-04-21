using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyMacroQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyMacroResults;
using GYM_Nutrition_Union.Application.Interfaces.DailyMacroInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler
{
    public class GetLatestDailyMacroByUserIdQueryHandler
    {
        private readonly IDailyMacroRepository _repository;

        public GetLatestDailyMacroByUserIdQueryHandler(IDailyMacroRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDailyMacroByUserIdQueryResult> Handle(GetLatestDailyMacroByUserIdQuery query)
        {
            return await _repository.GetLatestMacroByUserIdAsync(query.AppUserId);
        }
    }
}
