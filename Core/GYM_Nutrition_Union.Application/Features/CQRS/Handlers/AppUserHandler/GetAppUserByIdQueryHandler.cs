using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserResults;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler
{
	public class GetAppUserByIdQueryHandler
	{
		private readonly IRepository<AppUser> _repository;

		public GetAppUserByIdQueryHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAppUserByIdQueryResult
			{
				AppUserId = values.AppUserId,
				AppUserFirstName = values.AppUserFirstName,
				AppUserLastName = values.AppUserLastName,
				AppUserEmail = values.AppUserEmail,
				AppUserPassword = values.AppUserPassword
			};
		}
	}
}
