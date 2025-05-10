using GYM_Nurition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.JWTokenInterfaces
{
    public interface IJwtTokenInterface
    {
        (string Token, DateTime Expires) GenerateToken(AppUser user);
    }
}
