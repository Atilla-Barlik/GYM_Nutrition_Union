using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
	public class AppUser
	{
        public int AppUserId { get; set; }
        public string AppUserFirstName { get; set; }
        public string AppUserLastName { get; set;}
        public string AppUserEmail { get; set;}
        public string AppUserPassword { get; set;}
        public List<AppUserDetail> appUserDetails { get; set; }
        public List<AppUserExerciseProgram> appUserExerciseProgram { get;set; }
        public List<AppUserTrainingTime> appUserTrainingTime { get; set;}
        public List<AppUserBodyDetail> appUserBodyDetail { get; set;}
        public List<DailyNutrition> dailyNutritions { get; set; }
        public List<DailyMacro> dailyMacros { get; set; }
        public List<AvgKcalDailyResults> avgKcalDailyResults { get; set; }
	}
}
