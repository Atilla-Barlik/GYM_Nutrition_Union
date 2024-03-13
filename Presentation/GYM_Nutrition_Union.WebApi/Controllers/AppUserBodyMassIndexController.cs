using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyMassIndexCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyMassIndexHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserBodyMassIndexQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserBodyMassIndexController : ControllerBase
	{
		private readonly CreateAppUserBodyMassIndexCommandHandler _createAppUserBodyMassIndexCommandHandler;
		private readonly UpdateAppUserBodyMassIndexCommandHandler _updateAppUserBodyMassIndexCommandHandler;
		private readonly RemoveAppUserBodyMassIndexCommandHandler _removeAppUserBodyMassIndexCommandHandler;
		private readonly GetAppUserBodyMassIndexByIdQueryHandler _getAppUserBodyMassIndexByIdQueryHandler;
		private readonly GetAppUserBodyMassIndexQueryHandler _getAppUserBodyMassIndexQueryHandler;


		public AppUserBodyMassIndexController(CreateAppUserBodyMassIndexCommandHandler createAppUserBodyMassIndexCommandHandler, UpdateAppUserBodyMassIndexCommandHandler updateAppUserBodyMassIndexCommandHandler, RemoveAppUserBodyMassIndexCommandHandler removeAppUserBodyMassIndexCommandHandler, GetAppUserBodyMassIndexByIdQueryHandler getAppUserBodyMassIndexByIdQueryHandler, GetAppUserBodyMassIndexQueryHandler getAppUserBodyMassIndexQueryHandler)
		{
			_createAppUserBodyMassIndexCommandHandler = createAppUserBodyMassIndexCommandHandler;
			_updateAppUserBodyMassIndexCommandHandler = updateAppUserBodyMassIndexCommandHandler;
			_removeAppUserBodyMassIndexCommandHandler = removeAppUserBodyMassIndexCommandHandler;
			_getAppUserBodyMassIndexByIdQueryHandler = getAppUserBodyMassIndexByIdQueryHandler;
			_getAppUserBodyMassIndexQueryHandler = getAppUserBodyMassIndexQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AppUserBodyMassIndexList()
		{
			var values = await _getAppUserBodyMassIndexQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUserBodyMassIndex(int id)
		{
			var value = await _getAppUserBodyMassIndexByIdQueryHandler.Handle(new GetAppUserBodyMassIndexByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAppUserBodyMassIndex(CreateAppUserBodyMassIndexCommand command)
		{
			await _createAppUserBodyMassIndexCommandHandler.Handle(command);
			return Ok("AppUserBodyMassIndex Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveAppUserBodyMassIndex(int id)
		{
			await _removeAppUserBodyMassIndexCommandHandler.Handle(new RemoveAppUserBodyMassIndexCommand(id));
			return Ok("AppUserBodyMassIndex Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAppUserBodyMassIndex(UpdateAppUserBodyMassIndexCommand command)
		{
			await _updateAppUserBodyMassIndexCommandHandler.Handle(command);
			return Ok("AppUserBodyMassIndex Güncellendi.");
		}
	}
}
