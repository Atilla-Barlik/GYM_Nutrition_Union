using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AvgKcalDailyCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyMacroCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AvgKcalDailyHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionDetailQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvgKcalDailyController : ControllerBase
    {
        private readonly CreateAvgKcalDailyCommandHandler _avgKcalDailyCommandHandler;
        private readonly GetAvgKcalDailyQueryHandler _avgKcalDailyQueryHandler;
        private readonly GetLatestAvgKcalDailyByUserIdQueryHandler _avgKcalDailyByUserIdQueryHandler;

        public AvgKcalDailyController(CreateAvgKcalDailyCommandHandler avgKcalDailyCommandHandler, GetAvgKcalDailyQueryHandler avgKcalDailyQueryHandler, GetLatestAvgKcalDailyByUserIdQueryHandler avgKcalDailyByUserIdQueryHandler)
        {
            _avgKcalDailyCommandHandler = avgKcalDailyCommandHandler;
            _avgKcalDailyQueryHandler = avgKcalDailyQueryHandler;
            _avgKcalDailyByUserIdQueryHandler = avgKcalDailyByUserIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvgKcalDailyResults()
        {
            var values = await _avgKcalDailyQueryHandler.Handle();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDailyMacro(CreateAvgKcalDailyCommand command)
        {
            await _avgKcalDailyCommandHandler.Handle(command);
            return Ok("DailyMacro Eklendi.");
        }
        [HttpGet("avgKcalDaily/{appUserId}")]
        public async Task<IActionResult> GetAvgKcalDaily(int appUserId)
        {
            var result = await _avgKcalDailyByUserIdQueryHandler.Handle(new Application.Features.CQRS.Queries.GetAvgKcalDailyQueries.GetLatestAvgKcalDailyByUserIdQuery(appUserId));

            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}
