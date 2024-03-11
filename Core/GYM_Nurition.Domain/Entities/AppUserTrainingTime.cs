using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GYM_Nurition.Domain.Entities
{
	public class AppUserTrainingTime
	{
        public int AppUserTrainingTimeId { get; set; }
        public int TotalTrainingTime { get; set; }
        public int TotalKcalBurned { get; set; }
        public DateTime Date { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
