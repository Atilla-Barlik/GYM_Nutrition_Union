using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetDailyNutritionQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionDetailResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler
{
	public class GetDailyNutritionDetailByIdQueryHandler
	{
		private readonly IRepository<DailyNutritionDetails> _repository;

		public GetDailyNutritionDetailByIdQueryHandler(IRepository<DailyNutritionDetails> repository)
		{
			_repository = repository;
		}

		public async Task<GetDailyNutritionDetailByIdQueryResult> Handle(GetDailyNutritionDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetDailyNutritionDetailByIdQueryResult
			{
				DailyNutritionDetailsId = values.DailyNutritionDetailsId,
				DailyNutritionId = values.DailyNutritionId,
				NutrientName = values.NutrientName,
				NutrientImage = values.NutrientImage,
				NutrientKcal = values.NutrientKcal,
				NutrientProtein = values.NutrientProtein,
				NutrientCarbohydrate = values.NutrientCarbohydrate,
				NutrientFat = values.NutrientFat
			};
		}
	}
}
