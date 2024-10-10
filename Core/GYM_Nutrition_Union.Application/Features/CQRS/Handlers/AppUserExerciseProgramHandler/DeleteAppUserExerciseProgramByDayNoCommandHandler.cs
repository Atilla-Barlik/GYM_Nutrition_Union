using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler
{
    public class DeleteAppUserExerciseProgramByDayNoCommandHandler
    {
        private readonly IAppUserExerciseProgramRespository _appUserExerciseProgramRespository;

        public DeleteAppUserExerciseProgramByDayNoCommandHandler(IAppUserExerciseProgramRespository appUserExerciseProgramRespository)
        {
            _appUserExerciseProgramRespository = appUserExerciseProgramRespository;
        }

        public async Task Handle(DeleteAppUserExerciseProgramByDayNoCommand command)
        {
            await _appUserExerciseProgramRespository.DeleteByDayNoAsync(command.DayNo);
        }
    }
}
