using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseDetailCommands
{
	public class RemoveExerciseDetailCommand
	{
        public int Id { get; set; }

		public RemoveExerciseDetailCommand(int id)
		{
			Id = id;
		}
	}
}
