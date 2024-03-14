using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands
{
	public class RemoveDailyNutritionDetailCommand
	{
        public int Id { get; set; }

		public RemoveDailyNutritionDetailCommand(int id)
		{
			Id = id;
		}
	}
}
