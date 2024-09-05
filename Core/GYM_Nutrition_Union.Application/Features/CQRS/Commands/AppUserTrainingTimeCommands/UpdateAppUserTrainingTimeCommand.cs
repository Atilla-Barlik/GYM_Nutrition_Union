using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserTrainingTimeCommands
{
	public class UpdateAppUserTrainingTimeCommand
	{
		public int AppUserTrainingTimeId { get; set; }
		public int TotalTrainingTime { get; set; }
		public int TotalKcalBurned { get; set; }
		public TimeSpan Time{ get; set; }
		public int AppUserId { get; set; }
	}
}
