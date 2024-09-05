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
	public class UpdateAppUserTrainingTimeCommandHandler
	{
		private readonly IRepository<AppUserTrainingTime> _repository;

		public UpdateAppUserTrainingTimeCommandHandler(IRepository<AppUserTrainingTime> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAppUserTrainingTimeCommand command)
		{
			var values = await _repository.GetByIdAsync(command.AppUserTrainingTimeId);
			values.AppUserTrainingTimeId = command.AppUserTrainingTimeId;
			values.AppUserId = command.AppUserId;
			values.Time = command.Time;
			values.TotalKcalBurned = command.TotalKcalBurned;
			values.TotalTrainingTime = command.TotalTrainingTime;
			await _repository.UpdateAsync(values);
		}
	}
}
