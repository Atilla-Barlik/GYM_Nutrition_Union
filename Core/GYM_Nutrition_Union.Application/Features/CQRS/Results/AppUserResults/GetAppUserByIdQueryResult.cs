using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserResults
{
	public class GetAppUserByIdQueryResult
	{
		public int AppUserId { get; set; }
		public string AppUserFirstName { get; set; }
		public string AppUserLastName { get; set; }
		public string AppUserEmail { get; set; }
		public string AppUserPassword { get; set; }
	}
}
