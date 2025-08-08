using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserDetailResults;
using GYM_Nutrition_Union.Application.Interfaces.AppUserDetailInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.AppUserDetailRepositories
{
    public class AppUserDetailRepository : IAppUserDetailRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public AppUserDetailRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserDetailByIdQueryResult> getAppUserDetail(int userId)
        {
            var details = await _context.AppUsersDetail.FirstOrDefaultAsync(u => u.AppUserId == userId);
            return new GetAppUserDetailByIdQueryResult
            {
               AppUserId = userId,
               AfterImage = details.AfterImage,
               BeforeImage = details.BeforeImage,
               Age = details.Age,
               AppUserDetailId = details.AppUserDetailId,
               Length = details.Length,
               sex = details.sex,
               Weight = details.Weight
            };
        }

        public async Task<AppUserDetail> GetByUserId(int userId)
        {
            return await _context.AppUsersDetail.FirstOrDefaultAsync(u => u.AppUserId == userId);
        }
    }
}
