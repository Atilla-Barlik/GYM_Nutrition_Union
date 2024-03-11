using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.ExerciseResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler
{
	public class GetAppUserQueryHandler
	{
		private readonly IRepository<AppUser> _repository;

		public GetAppUserQueryHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppUserQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppUserQueryResult
			{
				AppUserId = x.AppUserId,
				AppUserFirstName = x.AppUserFirstName,
				AppUserLastName = x.AppUserLastName,
				AppUserEmail = x.AppUserEmail,
				AppUserPassword = x.AppUserPassword
			}).ToList();
		}
	}
}
