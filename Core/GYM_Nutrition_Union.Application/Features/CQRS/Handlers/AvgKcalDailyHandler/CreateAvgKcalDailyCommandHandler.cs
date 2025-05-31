using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AvgKcalDailyCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyMacroCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AvgKcalDailyHandler
{
    public class CreateAvgKcalDailyCommandHandler
    {

        private readonly IRepository<AvgKcalDailyResults> _repository;

        public CreateAvgKcalDailyCommandHandler(IRepository<AvgKcalDailyResults> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAvgKcalDailyCommand command)
        {
            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            await _repository.CreateAsync(new AvgKcalDailyResults
            {
                AppUserId = command.AppUserId,
                BurnKcal = command.BurnKcal,
                DailyMacro = command.DailyMacro,
                DailyTakenKcal = command.DailyTakenKcal,
                ResultKcal = command.ResultKcal,
                Date = dateOnly
            });
        }
    }
}

