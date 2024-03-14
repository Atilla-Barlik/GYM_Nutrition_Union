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
	public class RemoveAppUserTrainingTimeCommandHandler
	{
		private readonly IRepository<AppUserTrainingTime> _repository;

		public RemoveAppUserTrainingTimeCommandHandler(IRepository<AppUserTrainingTime> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAppUserTrainingTimeCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
