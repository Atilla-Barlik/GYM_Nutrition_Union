using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler
{
	public class CreateAppUserBodyDetailCommandHandler
	{
		private readonly IRepository<AppUserBodyDetail> _repository;

		public CreateAppUserBodyDetailCommandHandler(IRepository<AppUserBodyDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserBodyDetailCommand command)
		{
			await _repository.CreateAsync(new AppUserBodyDetail
			{
				AppUserId = command.AppUserId,
				Date = command.Date,
				Chest = command.Chest,
				Hips = command.Hips,
				LeftArm = command.LeftArm,
				RightArm = command.RightArm,
				LeftCalf = command.LeftCalf,
				RightCalf = command.RightCalf,
				LeftThigh = command.LeftThigh,
				RightThigh = command.RightThigh,
				Shoulder = command.Shoulder,
				Waist = command.Waist,
				Weight = command.Weight
			});
		}
	}
}
