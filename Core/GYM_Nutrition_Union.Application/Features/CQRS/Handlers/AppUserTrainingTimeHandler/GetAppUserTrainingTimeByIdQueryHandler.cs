using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserTrainingTimeQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserTrainingTimeResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserTrainingTimeHandler
{
	public class GetAppUserTrainingTimeByIdQueryHandler
	{
		private readonly IRepository<AppUserTrainingTime> _repository;

		public GetAppUserTrainingTimeByIdQueryHandler(IRepository<AppUserTrainingTime> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppUserTrainingTimeByIdQueryResult> Handle(GetAppUserTrainingTimeByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAppUserTrainingTimeByIdQueryResult
			{
				AppUserTrainingTimeId = values.AppUserTrainingTimeId,
				AppUserId = values.AppUserId,
				Date = values.Date,
				TotalKcalBurned = values.TotalKcalBurned,
				TotalTrainingTime = values.TotalTrainingTime
			};
		}
	}
}
