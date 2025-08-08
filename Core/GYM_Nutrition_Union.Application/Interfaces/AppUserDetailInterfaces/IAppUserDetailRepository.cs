using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.AppUserDetailInterfaces
{
    public interface IAppUserDetailRepository
    {
        Task<AppUserDetail> GetByUserId(int userId);
        Task<GetAppUserDetailByIdQueryResult> getAppUserDetail(int userId);
    }
}
