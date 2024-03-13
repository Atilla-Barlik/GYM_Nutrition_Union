using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyMassIndexCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyMassIndexHandler
{
	public class UpdateAppUserBodyMassIndexCommandHandler
	{
		private readonly IRepository<AppUserBodyMassIndex> _repository;

		public UpdateAppUserBodyMassIndexCommandHandler(IRepository<AppUserBodyMassIndex> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAppUserBodyMassIndexCommand command)
		{
			var values = await _repository.GetByIdAsync(command.AppUserBodyMassIndexId);
			values.AppUserBodyMassIndexId = command.AppUserBodyMassIndexId;
			values.AppUserDetailId = command.AppUserDetailId;
			values.LeanBodyMass = command.LeanBodyMass;
			values.BasalMetabolicRate = command.BasalMetabolicRate;
			values.BodyFatPercentage = command.BodyFatPercentage;
			values.BodyMassIndex = command.BodyMassIndex;
			await _repository.UpdateAsync(values);
		}
	}
}
