using GYM_Nurition.Domain.Entities;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseCommands
{
	public class UpdateExerciseCommand
	{
		public int ExerciseId { get; set; }
		public string ExerciseName { get; set; }
        public string ExerciseImage { get; set; }
    }
}
