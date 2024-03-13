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
	public class UpdateAppUserDetailCommandHandler
	{
		private readonly IRepository<AppUserDetail> _repository;

		public UpdateAppUserDetailCommandHandler(IRepository<AppUserDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAppUserDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.AppUserDetailId);
			values.AppUserDetailId = command.AppUserDetailId;
			values.AppUserId = command.AppUserId;
			values.BeforeImage =values.BeforeImage;
			values.AfterImage =values.AfterImage;
			values.sex = values.sex;
			values.Length = values.Length;
			values.Weight = values.Weight;
			await _repository.UpdateAsync(values);
		}
	}
}
