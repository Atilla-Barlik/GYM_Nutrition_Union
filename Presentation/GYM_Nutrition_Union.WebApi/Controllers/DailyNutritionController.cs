using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetDailyNutritionQueries;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DailyNutritionController : ControllerBase
	{
		private readonly CreateDailyNutritionCommandHandler _createDailyNutritionCommandHandler;
		private readonly UpdateDailyNutritionCommandHandler _updateDailyNutritionCommandHandler;
		private readonly RemoveDailyNutritionCommandHandler _removeDailyNutritionCommandHandler;
		private readonly GetDailyNutrientByIdQueryHandler _getDailyNutritionByIdQueryHandler;
		private readonly GetDailyNutritionQueryHandler _getDailyNutritionQueryHandler;
		private readonly CloseDailyNutritionCommandHandler _closeDailyNutritionCommandHandler;

        public DailyNutritionController(CreateDailyNutritionCommandHandler createDailyNutritionCommandHandler, UpdateDailyNutritionCommandHandler updateDailyNutritionCommandHandler, RemoveDailyNutritionCommandHandler removeDailyNutritionCommandHandler, GetDailyNutrientByIdQueryHandler getDailyNutritionByIdQueryHandler, GetDailyNutritionQueryHandler getDailyNutritionQueryHandler,
            CloseDailyNutritionCommandHandler closeDailyNutritionCommandHandler)
		{
			_createDailyNutritionCommandHandler = createDailyNutritionCommandHandler;
			_updateDailyNutritionCommandHandler = updateDailyNutritionCommandHandler;
			_removeDailyNutritionCommandHandler = removeDailyNutritionCommandHandler;
			_getDailyNutritionByIdQueryHandler = getDailyNutritionByIdQueryHandler;
			_getDailyNutritionQueryHandler = getDailyNutritionQueryHandler;
			_closeDailyNutritionCommandHandler = closeDailyNutritionCommandHandler;
			
		}

		[HttpGet]
		public async Task<IActionResult> DailyNutritionList()
		{
			var values = await _getDailyNutritionQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDailyNutrition(int id)
		{
			var value = await _getDailyNutritionByIdQueryHandler.Handle(new GetDailyNutritionByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateDailyNutrition(CreateDailyNutritionCommand command)
		{
			await _createDailyNutritionCommandHandler.Handle(command);
			return Ok("Besin Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveDailyNutrition(int id)
		{
			await _removeDailyNutritionCommandHandler.Handle(new RemoveDailyNutritionCommand(id));
			return Ok("Besin Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateDailyNutrition(UpdateDailyNutritionCommand command)
		{
			await _updateDailyNutritionCommandHandler.Handle(command);
			return Ok("Besin Güncellendi.");
		}
        [HttpPost("close/{dailyNutritionId}")]
        public async Task<IActionResult> Close(int dailyNutritionId)
        {
            try
            {
                await _closeDailyNutritionCommandHandler.Handle(new CloseDailyNutritionCommand(dailyNutritionId));
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
