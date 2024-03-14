using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
	public class GetDailyNutritionQueryHandler
	{
		private readonly IRepository<DailyNutrition> _repository;

		public GetDailyNutritionQueryHandler(IRepository<DailyNutrition> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDailyNutritionQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDailyNutritionQueryResult
			{
				DailyNutritionID = x.DailyNutritionID,
				AppUserId = x.AppUserId,
				DailyNutritionStatus = x.DailyNutritionStatus,
				DailyNutritionTotalKcal	= x.DailyNutritionTotalKcal,
				DailyNutritionTotalFat = x.DailyNutritionTotalFat,
				DailyNutritionTotalCarbohydrate = x.DailyNutritionTotalCarbohydrate,
				DailyNutritionTotalProtein = x.DailyNutritionTotalProtein,
				Date = x.Date
			}).ToList();
		}
	}
}
