using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyAvgKcalResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyMacroResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AvgKcalDailyHandler
{
    public class GetAvgKcalDailyQueryHandler
    {
        private readonly IRepository<AvgKcalDailyResults> _repository;

        public GetAvgKcalDailyQueryHandler(IRepository<AvgKcalDailyResults> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDailyAvgKcalQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDailyAvgKcalQueryResult
            {
               AppUserId = x.AppUserId,
               AvgKcalDailyResultsId = x.AvgKcalDailyResultsId,
               BurnKcal = x.BurnKcal,
               DailyMacro = x.DailyMacro,
               DailyTakenKcal = x.DailyTakenKcal,
               ResultKcal = x.ResultKcal,
                Date = x.Date
            }).ToList();
        }
    }
}
