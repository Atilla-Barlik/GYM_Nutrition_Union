using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserTrainingTimeCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserTrainingTimeHandler
{
	public class CreateAppUserTrainingTimeCommandHandler
	{
		private readonly IRepository<AppUserTrainingTime> _repository;

		public CreateAppUserTrainingTimeCommandHandler(IRepository<AppUserTrainingTime> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserTrainingTimeCommand command)
		{
			await _repository.CreateAsync(new AppUserTrainingTime
			{
				AppUserId = command.AppUserId,
				Date = command.Date,
				TotalKcalBurned = command.TotalKcalBurned,
				TotalTrainingTime = command.TotalTrainingTime,
			});
		}
	}
}
