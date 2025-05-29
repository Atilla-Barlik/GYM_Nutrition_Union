using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands
{
	public class UpdateAppUserExerciseProgramCommand
	{
		public int AppUserExerciseProgramId { get; set; }
		public int ExerciseRepeat { get; set; }
		public int ExerciseSet { get; set; }
		public decimal ExerciseWeight { get; set; }
		public bool ExerciseDone { get; set; }
		public int ExerciseTotalBurnedKcal { get; set; }
		public int ExerciseDetailId { get; set; }
		public int AppUserId { get; set; }
        public int DayNo { get; set; }
        public DateOnly Date { get; set; }
    }
}
