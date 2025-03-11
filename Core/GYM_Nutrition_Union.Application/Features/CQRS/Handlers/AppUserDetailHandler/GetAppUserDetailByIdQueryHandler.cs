using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserDetailResults;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler
{
	public class GetAppUserDetailByIdQueryHandler
	{
		private readonly IRepository<AppUserDetail> _repository;

		public GetAppUserDetailByIdQueryHandler(IRepository<AppUserDetail> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppUserDetailByIdQueryResult> Handle(GetAppUserDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAppUserDetailByIdQueryResult
			{
				AppUserDetailId = values.AppUserDetailId,
				AppUserId = values.AppUserId,
				BeforeImage = values.BeforeImage,
				AfterImage = values.AfterImage,
				Length = values.Length,
				Weight = values.Weight,
				sex = values.sex,
				Age = values.Age
			};
		}
	}
}
