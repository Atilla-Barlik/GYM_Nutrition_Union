using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserExerciseProgramQueries
{
	public class GetAppUserExerciseProgramByIdQuery
	{
		public int Id { get; set; }

		public GetAppUserExerciseProgramByIdQuery(int id)
		{
			Id = id;
		}
	}
}
