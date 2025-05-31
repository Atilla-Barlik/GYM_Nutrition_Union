using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AvgKcalDailyCommands
{
    public class CreateAvgKcalDailyCommand
    {
        public int AppUserId { get; set; }
        public decimal DailyMacro { get; set; }
        public decimal BurnKcal { get; set; }
        public decimal DailyTakenKcal { get; set; }
        public decimal ResultKcal { get; set; }
    }
}
