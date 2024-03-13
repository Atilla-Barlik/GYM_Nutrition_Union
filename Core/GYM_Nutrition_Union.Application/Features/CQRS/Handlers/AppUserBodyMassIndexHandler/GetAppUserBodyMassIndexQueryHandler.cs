using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserBodyDetailResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserBodyMassIndex;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyMassIndexHandler
{
	public class GetAppUserBodyMassIndexQueryHandler
	{
		private readonly IRepository<AppUserBodyMassIndex> _repository;

		public GetAppUserBodyMassIndexQueryHandler(IRepository<AppUserBodyMassIndex> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppUserBodyMassIndexQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppUserBodyMassIndexQueryResult
			{
				AppUserBodyMassIndexId = x.AppUserBodyMassIndexId,
				AppUserDetailId = x.AppUserDetailId,
				BasalMetabolicRate = x.BasalMetabolicRate,
				BodyFatPercentage = x.BodyFatPercentage,
				BodyMassIndex = x.BodyMassIndex,
				LeanBodyMass = x.LeanBodyMass
			}).ToList();
		}
	}
}
