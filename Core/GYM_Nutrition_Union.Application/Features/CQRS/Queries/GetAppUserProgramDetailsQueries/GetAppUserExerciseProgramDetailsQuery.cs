using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetAppUserProgramDetailsQueries
{
    public class GetAppUserExerciseProgramDetailsQuery
    {
        public GetAppUserExerciseProgramDetailsQuery(int appUserId)
        {
            AppUserId = appUserId;
        }

        public int AppUserId { get; set; }
    }
}
