using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.ModelViews
{
    public class ExerciseDetailWithPrograms
    {
        public ExerciseDetail ExerciseDetail { get; set; }
        [JsonIgnore]
        public List<AppUserExerciseProgram> UserPrograms { get; set; }
    }
}
