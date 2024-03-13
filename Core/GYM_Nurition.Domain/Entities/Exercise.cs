using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
	public class Exercise
	{
		public int ExerciseId { get; set; }
		public string ExerciseName { get; set; }
		public List<ExerciseDetail> ExerciseDetail { get; set; }
	}
}
