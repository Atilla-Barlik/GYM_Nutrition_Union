using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Results.ExerciseResults
{
	public class GetExerciseQueryResult
	{
		public int ExerciseId { get; set; }
		public string ExerciseName { get; set; }
        public string ExerciseImage { get; set; }

    }
}
