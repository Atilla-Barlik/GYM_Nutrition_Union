using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands
{
	public class RemoveDailyNutritionCommand
	{
        public int Id { get; set; }

		public RemoveDailyNutritionCommand(int id)
		{
			Id = id;
		}
	}
}
