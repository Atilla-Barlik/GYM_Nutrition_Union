using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserBodyDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserBodyDetailQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserBodyDetailController : ControllerBase
	{
		private readonly CreateAppUserBodyDetailCommandHandler _createAppUserBodyDetailCommandHandler;
		private readonly UpdateAppUserBodyDetailCommandHandler _updateAppUserBodyDetailCommandHandler;
		private readonly RemoveAppUserBodyDetailCommandHandler _removeAppUserBodyDetailCommandHandler;
		private readonly GetAppUserBodyDetailByIdQueryHandler _getAppUserBodyDetailByIdQueryHandler;
		private readonly GetAppUserBodyDetailQueryHandler _getAppUserBodyDetailQueryHandler;


		public AppUserBodyDetailController(CreateAppUserBodyDetailCommandHandler createAppUserBodyDetailCommandHandler, UpdateAppUserBodyDetailCommandHandler updateAppUserBodyDetailCommandHandler, RemoveAppUserBodyDetailCommandHandler removeAppUserBodyDetailCommandHandler, GetAppUserBodyDetailByIdQueryHandler getAppUserBodyDetailByIdQueryHandler, GetAppUserBodyDetailQueryHandler getAppUserBodyDetailQueryHandler)
		{
			_createAppUserBodyDetailCommandHandler = createAppUserBodyDetailCommandHandler;
			_updateAppUserBodyDetailCommandHandler = updateAppUserBodyDetailCommandHandler;
			_removeAppUserBodyDetailCommandHandler = removeAppUserBodyDetailCommandHandler;
			_getAppUserBodyDetailByIdQueryHandler = getAppUserBodyDetailByIdQueryHandler;
			_getAppUserBodyDetailQueryHandler = getAppUserBodyDetailQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AppUserBodyDetailList()
		{
			var values = await _getAppUserBodyDetailQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUserBodyDetail(int id)
		{
			var value = await _getAppUserBodyDetailByIdQueryHandler.Handle(new GetAppUserBodyDetailByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAppUserBodyDetail(CreateAppUserBodyDetailCommand command)
		{
			await _createAppUserBodyDetailCommandHandler.Handle(command);
			return Ok("AppUserBodyDetail Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveAppUserBodyDetail(int id)
		{
			await _removeAppUserBodyDetailCommandHandler.Handle(new RemoveAppUserBodyDetailCommand(id));
			return Ok("AppUserBodyDetail Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAppUserBodyDetail(UpdateAppUserBodyDetailCommand command)
		{
			await _updateAppUserBodyDetailCommandHandler.Handle(command);
			return Ok("AppUserBodyDetail Güncellendi.");
		}
	}
}
