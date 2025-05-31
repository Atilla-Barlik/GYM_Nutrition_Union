using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyAvgKcalResults
{
    public class GetDailyAvgKcalQueryResult
    {
        public int AvgKcalDailyResultsId { get; set; }
        public int AppUserId { get; set; }
        public decimal DailyMacro { get; set; }
        public decimal BurnKcal { get; set; }
        public decimal DailyTakenKcal { get; set; }
        public decimal ResultKcal { get; set; }
        public DateOnly Date { get; set; }
    }
}
