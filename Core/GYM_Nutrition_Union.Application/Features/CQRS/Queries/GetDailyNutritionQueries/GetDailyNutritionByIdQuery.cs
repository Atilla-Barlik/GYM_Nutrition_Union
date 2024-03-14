using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetDailyNutritionQueries
{
	public class GetDailyNutritionByIdQuery
	{
        public int Id { get; set; }

		public GetDailyNutritionByIdQuery(int id)
		{
			Id = id;
		}
	}
}
