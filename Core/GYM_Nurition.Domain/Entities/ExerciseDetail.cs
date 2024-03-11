using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
	public class ExerciseDetail
	{
		public int ExerciseDetailId { get; set; }
		public string Name { get; set; }
		public int AverageKcal { get; set; }
		public string Difficulty { get; set; }
		public string Equipment { get; set; }
		public string Description1 { get; set; }
		public string Description2 { get; set; }
		public string Description3 { get; set; }
		public string Description4 { get; set; }
		public string Gif1 { get; set; }
		public string Gif2 { get; set; }
		public string Gif3 { get; set; }
		public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
		public List<AppUserExerciseProgram> AppUserExerciseProgram { get; set; }

    }
}
