using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserResults;
using GYM_Nutrition_Union.Application.Interfaces.AppUserInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.JWTokenInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler
{
    public class AuthenticateUserQueryHandler
    {
        private readonly IAppUserRepository _repo;
        private readonly IPasswordHasher<AppUser> _hasher;
        private readonly IJwtTokenInterface _jwt;

        public AuthenticateUserQueryHandler(
          IAppUserRepository repo,
          IPasswordHasher<AppUser> hasher,
          IJwtTokenInterface jwt)
        {
            _repo = repo;
            _hasher = hasher;
            _jwt = jwt;
        }

        public async Task<int> Handle(AuthenticateUserQuery q)
        {
            var user = await _repo.GetByEmailAsync(q.Email);
            if (user == null)
                return -1;

            var result = _hasher.VerifyHashedPassword(user, user.AppUserPassword, q.Password);
            if (result == PasswordVerificationResult.Failed)
                return -1;

            return user.AppUserId;
        }
    }
}
