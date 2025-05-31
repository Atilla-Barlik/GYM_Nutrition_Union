using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
    public class AvgKcalDailyResults
    {
        public int AvgKcalDailyResultsId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public decimal DailyMacro { get; set; }
        public decimal BurnKcal { get; set; }
        public decimal DailyTakenKcal { get; set; }
        public decimal ResultKcal { get; set; }
        public DateOnly Date { get; set; }

    }
}
