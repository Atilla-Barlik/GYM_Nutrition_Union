using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserQueries
{
    public class AuthenticateUserQuery
    {
        public string Email { get; }
        public string Password { get; }
        public AuthenticateUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
