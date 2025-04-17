using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyNutritionCheckController : ControllerBase
    {
        private readonly GetDailyNutritionByUserIdAndDateQueryHandler _queryHandler;

        public DailyNutritionCheckController(GetDailyNutritionByUserIdAndDateQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetDailyNutrition(int userId)
        {
            var dailyNutrition = await _queryHandler.Handle(userId);

            if (dailyNutrition == null)
            {
                return NotFound(false);
            }

            return Ok(dailyNutrition);
        }
    }
}
