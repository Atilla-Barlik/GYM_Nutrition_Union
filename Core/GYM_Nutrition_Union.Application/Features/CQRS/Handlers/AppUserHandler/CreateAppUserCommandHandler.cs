using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Application.Interfaces.AppUserInterfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler
{
	public class CreateAppUserCommandHandler
	{
		private readonly IRepository<AppUser> _repository;
        private readonly IAppUserRepository _userRepository;
		private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly IRepository<AppUserDetail> _userDetailRepository;

		public CreateAppUserCommandHandler(IRepository<AppUser> repository, IPasswordHasher<AppUser> passwordHasher, IAppUserRepository appUserRepository,IRepository<AppUserDetail> appuserDetail)
		{
			_repository = repository;
			_passwordHasher = passwordHasher;
            _userRepository = appUserRepository;
            _userDetailRepository = appuserDetail;
		}

		public async Task Handle(CreateAppUserCommand command)
		{
            var emailAttr = new EmailAddressAttribute();
            if (!emailAttr.IsValid(command.AppUserEmail))
                throw new ValidationException("Lütfen geçerli bir e-posta adresi girin.");

            if (await _userRepository.EmailExistAsync(command.AppUserEmail))
                throw new InvalidOperationException("Bu e-posta adresi zaten kullanımda.");

            var user = new AppUser
            {
                AppUserFirstName = command.AppUserFirstName,
                AppUserLastName = command.AppUserLastName,
                AppUserEmail = command.AppUserEmail,
                // AppUserPassword'ı henüz atlamıyoruz
            };
            

            // Şifreyi hash’le
            user.AppUserPassword = _passwordHasher.HashPassword(user, command.AppUserPassword);

            await _repository.CreateAsync(user);
            await _userDetailRepository.CreateAsync(new AppUserDetail
            {
                AppUserId = user.AppUserId,
                AfterImage = " ",
                BeforeImage = " ",
                Length = 0,
                sex = true,
                Age = 0,
                Weight = 0
            });
        }
	}
}
