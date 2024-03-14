using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionDetailResults;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler
{
	public class GetDailyNutritionDetailQueryHandler
	{
		private readonly IRepository<DailyNutritionDetails> _repository;

		public GetDailyNutritionDetailQueryHandler(IRepository<DailyNutritionDetails> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDailyNutritionDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDailyNutritionDetailQueryResult
			{
				DailyNutritionDetailsId = x.DailyNutritionDetailsId,
				DailyNutritionId = x.DailyNutritionId,
				NutrientImage = x.NutrientImage,
				NutrientName = x.NutrientName,
				NutrientKcal = x.NutrientKcal,
				NutrientCarbohydrate = x.NutrientCarbohydrate,
				NutrientProtein = x.NutrientProtein,
				NutrientFat = x.NutrientFat
			}).ToList();
		}
	}
}
