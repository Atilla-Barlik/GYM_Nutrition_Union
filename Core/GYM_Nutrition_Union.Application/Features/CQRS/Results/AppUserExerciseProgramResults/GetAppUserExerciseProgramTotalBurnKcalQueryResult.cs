using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserExerciseProgramResults
{
    public class GetAppUserExerciseProgramTotalBurnKcalQueryResult
    {
        public int DayNo { get; set; }
        public int TotalBurnedKcal { get; set; }
    }
}
