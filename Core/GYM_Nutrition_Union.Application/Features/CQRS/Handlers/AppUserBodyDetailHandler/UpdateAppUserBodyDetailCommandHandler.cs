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
	public class UpdateAppUserBodyDetailCommandHandler
	{
		private readonly IRepository<AppUserBodyDetail> _repository;

		public UpdateAppUserBodyDetailCommandHandler(IRepository<AppUserBodyDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAppUserBodyDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.AppUserBodyDetailId);
			values.AppUserBodyDetailId = command.AppUserBodyDetailId;
			values.AppUserId = command.AppUserId;
			values.Date=command.Date;
			values.Chest = command.Chest;
			values.Hips = command.Hips;
			values.Shoulder = command.Shoulder;
			values.LeftArm = command.LeftArm;
			values.RightArm = command.RightArm;
			values.LeftThigh = command.LeftThigh;
			values.RightThigh = command.RightThigh;
			values.RightCalf = command.RightCalf;
			values.LeftCalf = command.LeftCalf;
			values.Weight = command.Weight;
			await _repository.UpdateAsync(values);
		}
	}
}
