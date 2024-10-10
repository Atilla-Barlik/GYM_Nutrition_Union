using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands
{
    public class DeleteAppUserExerciseProgramByDayNoCommand
    {
        public DeleteAppUserExerciseProgramByDayNoCommand(int dayNo)
        {
            DayNo = dayNo;
        }

        public int DayNo { get; set; }

    }
}
