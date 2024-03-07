using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseQueries
{
	public class GetExerciseByIdQuery
	{
		public GetExerciseByIdQuery(int id)
		{
			Id = id;
		}
		public int Id { get; set; }

	}
}
