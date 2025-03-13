using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Dtos.AppUserExerciseDtos
{
    public class AppUserExerciseStatisticsDto
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public DateOnly Date { get; set; }
        public int ExerciseRepeat { get; set; }
        public int ExerciseSet { get; set; }
        public decimal ExerciseWeight { get; set; }
        public decimal ExerciseTotalBurnedKcal { get; set; }
    }
}
