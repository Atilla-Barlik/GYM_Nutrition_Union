using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserDetailResults;
using GYM_Nutrition_Union.Application.Interfaces.AppUserDetailInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler
{
    public class GetAppUserDetailByUserIdQueryHandler
    {
        private readonly IAppUserDetailRepository _appUserDetailRepository;


        public GetAppUserDetailByUserIdQueryHandler(IAppUserDetailRepository appUserDetailRepository)
        {
            _appUserDetailRepository = appUserDetailRepository;
        }

        public async Task<GetAppUserDetailByIdQueryResult> Handle(GetAppUserDetailsByAppUserIdQuery handler)
        {
           return await _appUserDetailRepository.getAppUserDetail(handler.AppUserId);
        }
    }
}
