using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetDailyNutritionQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler
{
	public class GetDailyNutrientByIdQueryHandler
	{
		private readonly IRepository<DailyNutrition> _repository;

		public GetDailyNutrientByIdQueryHandler(IRepository<DailyNutrition> repository)
		{
			_repository = repository;
		}

		public async Task<GetDailyNutritionByIdQueryResult> Handle(GetDailyNutritionByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetDailyNutritionByIdQueryResult
			{
				DailyNutritionID = values.DailyNutritionID,
				AppUserId = values.AppUserId,
				Date = values.Date,
				DailyNutritionTotalKcal = values.DailyNutritionTotalKcal,
				DailyNutritionTotalCarbohydrate = values.DailyNutritionTotalCarbohydrate,
				DailyNutritionTotalProtein = values.DailyNutritionTotalProtein,
				DailyNutritionTotalFat = values.DailyNutritionTotalFat,
				DailyNutritionStatus = values.DailyNutritionStatus
			};
		}
	}
}
