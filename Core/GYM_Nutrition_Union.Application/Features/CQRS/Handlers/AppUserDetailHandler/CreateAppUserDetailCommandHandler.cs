using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserDetailCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler
{
	public class CreateAppUserDetailCommandHandler
	{
		private readonly IRepository<AppUserDetail> _repository;

		public CreateAppUserDetailCommandHandler(IRepository<AppUserDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserDetailCommand command)
		{
			await _repository.CreateAsync(new AppUserDetail
			{
				AppUserId = command.AppUserId,
				AfterImage = command.AfterImage,
				BeforeImage = command.BeforeImage,
				Length = command.Length,
				sex = command.sex,
				Weight = command.Weight
			});
		}
	}
}
