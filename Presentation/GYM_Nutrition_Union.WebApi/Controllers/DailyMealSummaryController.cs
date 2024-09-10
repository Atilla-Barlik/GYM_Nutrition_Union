using GYM_Nurition.Domain.Dtos;
using GYM_Nutrition_Union.Application.Interfaces.DailyMealTimeInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMealSummaryController : ControllerBase
    {
        private readonly IDailyMealTotalsRespository _dailyMealTotalsRespository;

        public DailyMealSummaryController(IDailyMealTotalsRespository dailyMealTotalsRespository)
        {
            _dailyMealTotalsRespository = dailyMealTotalsRespository;
        }

        [HttpGet("summary/{dailyNutritionId}")]
        public async Task<ActionResult<NutritionSummaryDto>> GetNutritionSummary(int dailyNutritionId)
        {
            var summary = await _dailyMealTotalsRespository.GetNutritionSummary(dailyNutritionId);

            if (summary == null)
            {
                return NotFound();
            }

            return Ok(summary);
        }
    }
}
