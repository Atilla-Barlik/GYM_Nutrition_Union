using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserTrainingTimeResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserTrainingTimeHandler
{
	public class GetAppUserTrainingTimeQueryHandler
	{
		private readonly IRepository<AppUserTrainingTime> _repository;

		public GetAppUserTrainingTimeQueryHandler(IRepository<AppUserTrainingTime> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppUserTrainingTimeQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppUserTrainingTimeQueryResult
			{
				AppUserTrainingTimeId = x.AppUserTrainingTimeId,
				AppUserId = x.AppUserId,
				Time = x.Time,
				TotalKcalBurned = x.TotalKcalBurned,
				TotalTrainingTime = x.TotalTrainingTime
			}).ToList();
		}
	}
}
