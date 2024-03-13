using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserDetailResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.ExerciseDetailResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				sex = values.sex
			};
		}
	}
}
