using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyMassIndexCommands
{
	public class RemoveAppUserBodyMassIndexCommand
	{
        public int Id { get; set; }

		public RemoveAppUserBodyMassIndexCommand(int id)
		{
			Id = id;
		}
	}
}
