using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetAvgKcalDailyQueries
{
    public class GetAvgKcalDailyQueries
    {
        public int Id { get; set; }

        public GetAvgKcalDailyQueries(int id)
        {
            Id = id;
        }
    }
}
