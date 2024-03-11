using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GYM_Nurition.Domain.Entities
{
	public class DailyNutrition
	{
		public int DailyNutritionID { get; set; }
		public bool DailyNutritionStatus { get; set; }
		public int DailyNutritionTotalKcal { get; set; }
		public decimal DailyNutritionTotalCarbohydrate { get; set; }
		public decimal DailyNutritionTotalProtein { get; set; }
		public decimal DailyNutritionTotalFat { get; set; }
		public DateTime Date { get; set; }
		public AppUser AppUser { get; set; }
		public int AppUserId { get; set; }
		public List<DailyNutritionDetails> DailyNutritionDetails { get; set; }
	}
}
