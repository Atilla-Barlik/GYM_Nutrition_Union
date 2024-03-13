using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler
{
	public class RemoveAppUserDetailCommandHandler
	{
		private readonly IRepository<AppUserDetail> _repository;

		public RemoveAppUserDetailCommandHandler(IRepository<AppUserDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAppUserDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
