using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramDetailsHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserExerciseProgramQueries;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserExerciseStatisticsController : ControllerBase
    {
        private readonly GetUserExerciseStatisticsQueryHandler _queryHandler;

        public AppUserExerciseStatisticsController(IAppUserExerciseStatisticsRepository repository)
        {
            _queryHandler = new GetUserExerciseStatisticsQueryHandler(repository);
        }

        [HttpGet("user/{appUserId}/statistics")]
        public async Task<IActionResult> GetUserExerciseStatistics(int appUserId)
        {
            var query = new GetUserExerciseStatisticsQuery
            {
                AppUserId = appUserId
            };

            var result = await _queryHandler.Handle(query);

            if (result == null || !result.Any())
            {
                return NotFound("Bu kullanıcı için istatistik bulunamadı.");
            }

            return Ok(result);
        }
    }
}
