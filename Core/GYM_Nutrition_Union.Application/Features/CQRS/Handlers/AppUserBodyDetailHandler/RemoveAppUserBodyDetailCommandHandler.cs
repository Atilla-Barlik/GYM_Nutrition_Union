using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler
{
	public class RemoveAppUserBodyDetailCommandHandler
	{
		private readonly IRepository<AppUserBodyDetail> _repository;

		public RemoveAppUserBodyDetailCommandHandler(IRepository<AppUserBodyDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAppUserBodyDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
