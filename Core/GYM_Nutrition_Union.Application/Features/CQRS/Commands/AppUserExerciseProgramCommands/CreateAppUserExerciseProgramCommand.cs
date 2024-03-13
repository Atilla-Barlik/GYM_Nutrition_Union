using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands
{
	public class CreateAppUserExerciseProgramCommand
	{
		public int ExerciseRepeat { get; set; }
		public int ExerciseSet { get; set; }
		public int ExerciseTotalBurnedKcal { get; set; }
		public int ExerciseDetailId { get; set; }
		public int AppUserId { get; set; }
	}
}
