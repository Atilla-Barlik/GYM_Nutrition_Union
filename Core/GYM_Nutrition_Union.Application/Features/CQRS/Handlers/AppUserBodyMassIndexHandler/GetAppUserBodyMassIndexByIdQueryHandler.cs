using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserBodyDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserBodyMassIndexQueries;
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
	public class GetAppUserBodyMassIndexByIdQueryHandler
	{
		private readonly IRepository<AppUserBodyMassIndex> _repository;

		public GetAppUserBodyMassIndexByIdQueryHandler(IRepository<AppUserBodyMassIndex> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppUserBodyMassIndexByIdQueryResult> Handle(GetAppUserBodyMassIndexByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAppUserBodyMassIndexByIdQueryResult
			{
				AppUserBodyMassIndexId = values.AppUserBodyMassIndexId,
				AppUserDetailId = values.AppUserDetailId,
				BodyFatPercentage = values.BodyFatPercentage,
				BasalMetabolicRate = values.BasalMetabolicRate,
				BodyMassIndex = values.BodyMassIndex,
				LeanBodyMass = values.LeanBodyMass
			};
		}
	}
}
