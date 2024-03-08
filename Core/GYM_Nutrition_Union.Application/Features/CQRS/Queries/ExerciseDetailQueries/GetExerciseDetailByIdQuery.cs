using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseDetailQueries
{
	public class GetExerciseDetailByIdQuery
	{
        public int Id { get; set; }

		public GetExerciseDetailByIdQuery(int id)
		{
			Id = id;
		}
	}
}
