using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler
{
	public class CreateAppUserCommandHandler
	{
		private readonly IRepository<AppUser> _repository;

		public CreateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserCommand command)
		{
			await _repository.CreateAsync(new AppUser
			{
				AppUserFirstName = command.AppUserFirstName,
				AppUserLastName = command.AppUserLastName,
				AppUserEmail = command.AppUserEmail,
				AppUserPassword = command.AppUserPassword,
			});
		}
	}
}
