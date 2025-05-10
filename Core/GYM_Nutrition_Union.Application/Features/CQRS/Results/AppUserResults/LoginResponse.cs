using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserResults
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
