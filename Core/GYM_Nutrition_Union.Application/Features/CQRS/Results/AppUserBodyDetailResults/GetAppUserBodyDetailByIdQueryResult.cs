using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserBodyDetailResults
{
	public class GetAppUserBodyDetailByIdQueryResult
	{
		public int AppUserBodyDetailId { get; set; }
		public DateTime Date { get; set; }
		public int Chest { get; set; }
		public int LeftArm { get; set; }
		public int RightArm { get; set; }
		public int Waist { get; set; }
		public int Hips { get; set; }
		public int LeftThigh { get; set; }
		public int RightThigh { get; set; }
		public int LeftCalf { get; set; }
		public int RightCalf { get; set; }
		public decimal Weight { get; set; }
		public int Shoulder { get; set; }
		public int AppUserId { get; set; }
	}
}
