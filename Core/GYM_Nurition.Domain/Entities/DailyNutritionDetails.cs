using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
	public class DailyNutritionDetails
	{
        public int DailyNutritionDetailsId { get; set; }
        public string NutrientName { get; set; }
        public string NutrientImage { get; set; }
        public int NutrientKcal { get; set; }
        public decimal NutrientCarbohydrate { get; set; }
        public decimal NutrientProtein { get; set; }
        public decimal NutrientFat { get; set; }
        public DailyNutrition DailyNutrition { get; set; }
        public int DailyNutritionId { get; set; }
        public int DailyMealTime { get; set; }
    }
}
