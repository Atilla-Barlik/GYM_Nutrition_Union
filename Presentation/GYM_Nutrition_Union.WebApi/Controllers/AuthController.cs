using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticateUserQueryHandler _handler;

        public AuthController(AuthenticateUserQueryHandler handler)
        {
            _handler = handler;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {

            var userId = await _handler.Handle(new AuthenticateUserQuery(dto.Email, dto.Password));

            // 2) Başarısızsa 401
            if (userId < 0)
                return Unauthorized("E-posta veya parola hatalı.");

            // 3) Başarılıysa sadece UserId dön
            return Ok(new { userId });
        }
    }
}
