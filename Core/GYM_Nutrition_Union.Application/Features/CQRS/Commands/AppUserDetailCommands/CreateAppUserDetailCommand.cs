using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserDetailCommands
{
	public class CreateAppUserDetailCommand
	{
		public int Length { get; set; }
		public decimal Weight { get; set; }
		public string BeforeImage { get; set; }
		public string AfterImage { get; set; }
		public bool sex { get; set; }
        public int Age { get; set; }
        public int AppUserId { get; set; }
	}
}
