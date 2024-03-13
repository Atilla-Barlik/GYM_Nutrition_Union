using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyDetailCommands
{
	public class RemoveAppUserBodyDetailCommand
	{
        public int Id { get; set; }

		public RemoveAppUserBodyDetailCommand(int id)
		{
			Id = id;
		}
	}
}
