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
	public class RemoveAppUserBodyMassIndexCommandHandler
	{
		private readonly IRepository<AppUserBodyMassIndex> _repository;

		public RemoveAppUserBodyMassIndexCommandHandler(IRepository<AppUserBodyMassIndex> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAppUserBodyMassIndexCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
