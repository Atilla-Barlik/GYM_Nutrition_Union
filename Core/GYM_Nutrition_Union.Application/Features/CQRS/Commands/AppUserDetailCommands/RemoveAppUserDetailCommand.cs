using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserDetailCommands
{
	public class RemoveAppUserDetailCommand
	{
        public int Id { get; set; }

		public RemoveAppUserDetailCommand(int id)
		{
			Id = id;
		}
	}
}
