using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands
{
	public class UpdateDailyNutritionDetailCommand
	{
		public int DailyNutritionDetailsId { get; set; }
		public string NutrientName { get; set; }
		public string NutrientImage { get; set; }
		public int NutrientKcal { get; set; }
		public decimal NutrientCarbohydrate { get; set; }
		public decimal NutrientProtein { get; set; }
		public decimal NutrientFat { get; set; }
		public int DailyNutritionId { get; set; }
	}
}
