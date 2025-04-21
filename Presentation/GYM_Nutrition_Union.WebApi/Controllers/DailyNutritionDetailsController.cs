using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionDetailQueries;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionDetailInterfaces;
using GYM_Nutrition_Union.Persistence.Repositories.DailyNutritionDetailRepositories;
using GYM_NutritionDetails_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DailyNutritionDetailsController : ControllerBase
	{
		private readonly CreateDailyNutritionDetailCommandHandler _createDailyNutritionDetailCommandHandler;
		private readonly UpdateDailyNutritionDetailCommandHandler _updateDailyNutritionDetailCommandHandler;
		private readonly RemoveDailyNutritionDetailCommandHandler _removeDailyNutritionDetailCommandHandler;
		private readonly GetDailyNutritionDetailByIdQueryHandler _getDailyNutritionDetailByIdQueryHandler;
		private readonly GetDailyNutritionDetailQueryHandler _getDailyNutritionDetailQueryHandler;
		private readonly GetLatestNutritionDetailsByUserIdQueryHandler _getLatestNutritionDetailsByUserIdQueryHandler;

		public DailyNutritionDetailsController(CreateDailyNutritionDetailCommandHandler createDailyNutritionDetailCommandHandler, UpdateDailyNutritionDetailCommandHandler updateDailyNutritionDetailCommandHandler, RemoveDailyNutritionDetailCommandHandler removeDailyNutritionDetailCommandHandler, GetDailyNutritionDetailByIdQueryHandler getDailyNutritionDetailByIdQueryHandler, GetDailyNutritionDetailQueryHandler getDailyNutritionDetailQueryHandler,
            GetLatestNutritionDetailsByUserIdQueryHandler getLatestNutritionDetailsByUserIdQueryHandler)
		{
			_createDailyNutritionDetailCommandHandler = createDailyNutritionDetailCommandHandler;
			_updateDailyNutritionDetailCommandHandler = updateDailyNutritionDetailCommandHandler;
			_removeDailyNutritionDetailCommandHandler = removeDailyNutritionDetailCommandHandler;
			_getDailyNutritionDetailByIdQueryHandler = getDailyNutritionDetailByIdQueryHandler;
			_getDailyNutritionDetailQueryHandler = getDailyNutritionDetailQueryHandler;
			_getLatestNutritionDetailsByUserIdQueryHandler = getLatestNutritionDetailsByUserIdQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> DailyNutritionDetailList()
		{
			var values = await _getDailyNutritionDetailQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDailyNutritionDetail(int id)
		{
			var value = await _getDailyNutritionDetailByIdQueryHandler.Handle(new GetDailyNutritionDetailByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateDailyNutritionDetail(CreateDailyNutritionDetailCommand command)
		{
			await _createDailyNutritionDetailCommandHandler.Handle(command);
			return Ok("DailyNutritionDetail Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveDailyNutritionDetail(int id)
		{
			await _removeDailyNutritionDetailCommandHandler.Handle(new RemoveDailyNutritionDetailCommand(id));
			return Ok("DailyNutritionDetail Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateDailyNutritionDetail(UpdateDailyNutritionDetailCommand command)
		{
			await _updateDailyNutritionDetailCommandHandler.Handle(command);
			return Ok("DailyNutritionDetail Güncellendi.");
		}

        [HttpGet("latest-nutrition-details/{appUserId}")]
        public async Task<IActionResult> GetLatestNutritionDetails(int appUserId)
        {
            var result = await _getLatestNutritionDetailsByUserIdQueryHandler.Handle(new GetLatestNutritionDetailsByUserIdQuery(appUserId));

            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}
