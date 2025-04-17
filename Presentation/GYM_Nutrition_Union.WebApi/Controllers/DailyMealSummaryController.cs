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

        [HttpGet("summary/user/{appUserId}")]
        public async Task<ActionResult<List<NutritionSummaryDto>>> GetNutritionSummary(int appUserId)
        {
            var summary = await _dailyMealTotalsRespository.GetNutritionSummary(appUserId);

            if (summary == null || !summary.Any())
            {
                return NotFound("Bugüne ait beslenme kaydı bulunamadı.");
            }

            return Ok(summary);
        }
    }
}
