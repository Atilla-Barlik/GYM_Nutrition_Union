using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands
{
	public class RemoveAppUserExerciseProgramCommand
	{
        public int Id { get; set; }

		public RemoveAppUserExerciseProgramCommand(int id)
		{
			Id = id;
		}
	}
}
