using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Results.DailyNutritionResults
{
	public class GetDailyNutritionByIdQueryResult
	{
		public int DailyNutritionID { get; set; }
		public bool DailyNutritionStatus { get; set; }
		public int DailyNutritionTotalKcal { get; set; }
		public decimal DailyNutritionTotalCarbohydrate { get; set; }
		public decimal DailyNutritionTotalProtein { get; set; }
		public decimal DailyNutritionTotalFat { get; set; }
		public DateOnly Date { get; set; }
		public int AppUserId { get; set; }
	}
}
