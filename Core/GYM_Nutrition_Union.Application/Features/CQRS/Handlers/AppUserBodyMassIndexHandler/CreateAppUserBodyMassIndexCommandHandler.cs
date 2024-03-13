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
	public class CreateAppUserBodyMassIndexCommandHandler
	{
		private readonly IRepository<AppUserBodyMassIndex> _repository;

		public CreateAppUserBodyMassIndexCommandHandler(IRepository<AppUserBodyMassIndex> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserBodyMassIndexCommand command)
		{
			await _repository.CreateAsync(new AppUserBodyMassIndex
			{
				AppUserDetailId = command.AppUserDetailId,
				BasalMetabolicRate = command.BasalMetabolicRate,
				BodyFatPercentage = command.BodyFatPercentage,
				BodyMassIndex = command.BodyMassIndex,
				LeanBodyMass = command.LeanBodyMass
			});
		}
	}
}
