using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserTrainingTimeCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserTrainingTimeHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserTrainingTimeQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserTrainingTimeController : ControllerBase
	{
		private readonly CreateAppUserTrainingTimeCommandHandler _createAppUserTrainingTimeCommandHandler;
		private readonly UpdateAppUserTrainingTimeCommandHandler _updateAppUserTrainingTimeCommandHandler;
		private readonly RemoveAppUserTrainingTimeCommandHandler _removeAppUserTrainingTimeCommandHandler;
		private readonly GetAppUserTrainingTimeByIdQueryHandler _getAppUserTrainingTimeByIdQueryHandler;
		private readonly GetAppUserTrainingTimeQueryHandler _getAppUserTrainingTimeQueryHandler;


		public AppUserTrainingTimeController(CreateAppUserTrainingTimeCommandHandler createAppUserTrainingTimeCommandHandler, UpdateAppUserTrainingTimeCommandHandler updateAppUserTrainingTimeCommandHandler, RemoveAppUserTrainingTimeCommandHandler removeAppUserTrainingTimeCommandHandler, GetAppUserTrainingTimeByIdQueryHandler getAppUserTrainingTimeByIdQueryHandler, GetAppUserTrainingTimeQueryHandler getAppUserTrainingTimeQueryHandler)
		{
			_createAppUserTrainingTimeCommandHandler = createAppUserTrainingTimeCommandHandler;
			_updateAppUserTrainingTimeCommandHandler = updateAppUserTrainingTimeCommandHandler;
			_removeAppUserTrainingTimeCommandHandler = removeAppUserTrainingTimeCommandHandler;
			_getAppUserTrainingTimeByIdQueryHandler = getAppUserTrainingTimeByIdQueryHandler;
			_getAppUserTrainingTimeQueryHandler = getAppUserTrainingTimeQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AppUserTrainingTimeList()
		{
			var values = await _getAppUserTrainingTimeQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUserTrainingTime(int id)
		{
			var value = await _getAppUserTrainingTimeByIdQueryHandler.Handle(new GetAppUserTrainingTimeByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAppUserTrainingTime(CreateAppUserTrainingTimeCommand command)
		{
			await _createAppUserTrainingTimeCommandHandler.Handle(command);
			return Ok("AppUserTrainingTime Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveAppUserTrainingTime(int id)
		{
			await _removeAppUserTrainingTimeCommandHandler.Handle(new RemoveAppUserTrainingTimeCommand(id));
			return Ok("AppUserTrainingTime Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAppUserTrainingTime(UpdateAppUserTrainingTimeCommand command)
		{
			await _updateAppUserTrainingTimeCommandHandler.Handle(command);
			return Ok("AppUserTrainingTime Güncellendi.");
		}
	}
}
