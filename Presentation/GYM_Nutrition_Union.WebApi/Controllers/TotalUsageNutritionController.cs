using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalUsageNutritionController : ControllerBase
    {
        private readonly GetTop10NutrientsQueryHandler _queryHandler;

        public TotalUsageNutritionController(GetTop10NutrientsQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10Nutrients()
        {
            var result = await _queryHandler.Handle();
            return Ok(result);
        }
    }
}
