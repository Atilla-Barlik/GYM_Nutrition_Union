using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
	public class AppUserExerciseProgram
	{
        public int AppUserExerciseProgramId { get; set; }
        public int ExerciseRepeat { get; set; }
        public int ExerciseSet { get; set; }
        public decimal ExerciseWeight { get; set; }
        public int ExerciseTotalBurnedKcal { get; set; }
        public ExerciseDetail exerciseDetail { get; set; }
        public int ExerciseDetailId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public int DayNo { get; set; }
        public DateOnly Date { get; set; }
    }

}
