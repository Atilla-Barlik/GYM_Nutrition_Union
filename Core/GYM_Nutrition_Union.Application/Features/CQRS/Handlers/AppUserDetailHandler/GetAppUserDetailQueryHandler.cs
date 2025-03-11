using GYM_Nurition.Domain.Entities;
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
	public class GetAppUserDetailQueryHandler
	{
		private readonly IRepository<AppUserDetail> _repository;

		public GetAppUserDetailQueryHandler(IRepository<AppUserDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppUserDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppUserDetailQueryResult
			{
				AppUserDetailId = x.AppUserDetailId,
				AppUserId = x.AppUserId,
				AfterImage = x.AfterImage,
				BeforeImage = x.BeforeImage,
				sex = x.sex,
				Age = x.Age,
				Length = x.Length,
				Weight = x.Weight,
			}).ToList();
		}
	}
}
