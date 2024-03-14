using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserTrainingTimeCommands
{
	public class RemoveAppUserTrainingTimeCommand
	{
        public int Id { get; set; }

		public RemoveAppUserTrainingTimeCommand(int id)
		{
			Id = id;
		}
	}
}
