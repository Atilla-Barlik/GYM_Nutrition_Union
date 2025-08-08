using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserDetailQueries
{
    public class GetAppUserDetailsByAppUserIdQuery
    {
        public int AppUserId { get; set; }
        public GetAppUserDetailsByAppUserIdQuery(int  appUserId) => AppUserId = appUserId;
    }
}
