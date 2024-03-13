using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserBodyDetailResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserDetailResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler
{
	public class GetAppUserBodyDetailQueryHandler
	{
		private readonly IRepository<AppUserBodyDetail> _repository;

		public GetAppUserBodyDetailQueryHandler(IRepository<AppUserBodyDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppUserBodyDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppUserBodyDetailQueryResult
			{
				AppUserBodyDetailId = x.AppUserBodyDetailId,
				AppUserId = x.AppUserId,
				Weight = x.Weight,
				Date = x.Date,
				Chest = x.Chest,
				Hips = x.Hips,
				LeftArm = x.LeftArm,
				RightArm = x.RightArm,
				LeftCalf = x.LeftCalf,
				RightCalf = x.RightCalf,
				LeftThigh = x.LeftThigh,
				RightThigh = x.RightThigh,
				Shoulder = x.Shoulder,
				Waist = x.Waist
			}).ToList();
		}
	}
}
