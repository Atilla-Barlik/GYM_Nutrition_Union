using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GYM_Nurition.Domain.Entities
{
	public class AppUserBodyDetail
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
        public AppUser appUser { get; set; }
        public int AppUserId { get; set; }
    }
}
