using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetAvgKcalDailyQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyAvgKcalResults;
using GYM_Nutrition_Union.Application.Interfaces.AvgKcalDailyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AvgKcalDailyHandler
{
    public class GetLatestAvgKcalDailyByUserIdQueryHandler
    {
        private readonly IAvgKcalDailyRepository _vgKcalDailyRepository;

        public GetLatestAvgKcalDailyByUserIdQueryHandler(IAvgKcalDailyRepository vgKcalDailyRepository)
        {
            _vgKcalDailyRepository = vgKcalDailyRepository;
        }

        public async Task<List<GetAvgKcalDailyByUserIdQueryResult>> Handle(GetLatestAvgKcalDailyByUserIdQuery query)
        {
            return await _vgKcalDailyRepository.GetLatestAvgKcalDailyByUserIdAsync(query.AppUserId);
        }
    }
}
