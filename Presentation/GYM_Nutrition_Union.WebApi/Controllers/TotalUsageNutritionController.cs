using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.UserMostUsedNutrientsQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalUsageNutritionController : ControllerBase
    {
        private readonly GetTop10NutrientsQueryHandler _queryHandler;
        private readonly GetUserMostUsedNutrientsQueryHandler _userMostUsedNutrientsQueryHandler;

        public TotalUsageNutritionController(GetTop10NutrientsQueryHandler queryHandler, GetUserMostUsedNutrientsQueryHandler userMostUsedNutrientsQueryHandler)
        {
            _queryHandler = queryHandler;
            _userMostUsedNutrientsQueryHandler = userMostUsedNutrientsQueryHandler;
        }

        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10Nutrients()
        {
            var result = await _queryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("userTop10/{appUserId}")]
        public async Task<IActionResult> GetTop10UserNutrients(int appUserId)
        {
            var query = new GetMostUsedNutrientQuery(appUserId);
            var result = await _userMostUsedNutrientsQueryHandler.Handle(query);
            if (result == null)
            {
                return NotFound(new { Message = "No nutrients found for the given user." });
            }    
            return Ok(result);
        }
    }
}
