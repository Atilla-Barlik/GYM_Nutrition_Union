namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseCommands
{
	public class RemoveExerciseCommand
	{
        public int Id { get; set; }

		public RemoveExerciseCommand(int id)
		{
			Id = id;
		}
	}
}
