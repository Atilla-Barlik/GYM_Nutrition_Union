using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserBodyDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserBodyDetailResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler
{
	public class GetAppUserBodyDetailByIdQueryHandler
	{
		private readonly IRepository<AppUserBodyDetail> _repository;

		public GetAppUserBodyDetailByIdQueryHandler(IRepository<AppUserBodyDetail> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppUserBodyDetailByIdQueryResult> Handle(GetAppUserBodyDetailByIdQuery query)
		{
            var values = await _repository.GetByIdAsync(query.Id);
			return new GetAppUserBodyDetailByIdQueryResult
			{
				AppUserBodyDetailId = values.AppUserBodyDetailId,
				AppUserId = values.AppUserId,
				Date = values.Date,
				Chest = values.Chest,
				Waist = values.Waist,
				Shoulder = values.Shoulder,
				Hips = values.Hips,
				LeftArm = values.LeftArm,
				RightArm = values.RightArm,
				LeftCalf = values.LeftCalf,
				RightCalf = values.RightCalf,
				LeftThigh = values.LeftThigh,
				RightThigh = values.RightThigh,
				Weight = values.Weight
			};
		}
	}
}
