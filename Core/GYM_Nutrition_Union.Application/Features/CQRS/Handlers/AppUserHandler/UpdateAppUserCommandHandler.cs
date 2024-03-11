using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserCommands;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler
{
	public class UpdateAppUserCommandHandler
	{
		private readonly IRepository<AppUser> _repository;

		public UpdateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAppUserCommand command)
		{
			var values = await _repository.GetByIdAsync(command.AppUserId);
			values.AppUserId = command.AppUserId;
			values.AppUserFirstName = command.AppUserFirstName;
			values.AppUserLastName = command.AppUserLastName;
			values.AppUserEmail = command.AppUserEmail;
			values.AppUserPassword = command.AppUserPassword;
			await _repository.UpdateAsync(values);
		}
	}
}
