using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseDetailsWithExerciseIdController : ControllerBase
    {
        private readonly GetExerciseDetailsWithExerciseIdQueryHandler _getExerciseDetailsWithExerciseIdQueryHandler;

        public ExerciseDetailsWithExerciseIdController(GetExerciseDetailsWithExerciseIdQueryHandler getExerciseDetailsWithExerciseIdQueryHandler)
        {
            _getExerciseDetailsWithExerciseIdQueryHandler = getExerciseDetailsWithExerciseIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetExerciseDetailsWithExerciseId(int id)
        {
            var values = await _getExerciseDetailsWithExerciseIdQueryHandler.Handle(id);
            return Ok(values);
        }
    }
}
