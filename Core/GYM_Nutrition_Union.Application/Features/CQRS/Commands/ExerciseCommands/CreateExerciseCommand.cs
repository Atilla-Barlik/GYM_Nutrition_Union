using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseCommands
{
	public class CreateExerciseCommand
	{
		public string ExerciseName { get; set; }
		
	}
}
