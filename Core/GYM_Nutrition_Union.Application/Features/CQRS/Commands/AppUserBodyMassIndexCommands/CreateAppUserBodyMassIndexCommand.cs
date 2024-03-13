using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyMassIndexCommands
{
	public class CreateAppUserBodyMassIndexCommand
	{
		public decimal BodyMassIndex { get; set; }
		public decimal LeanBodyMass { get; set; }
		public decimal BodyFatPercentage { get; set; }
		public decimal BasalMetabolicRate { get; set; }
		public int AppUserDetailId { get; set; }
	}
}
