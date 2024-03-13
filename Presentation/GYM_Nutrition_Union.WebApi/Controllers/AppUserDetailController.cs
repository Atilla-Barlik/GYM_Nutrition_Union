using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserDetailQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserDetailController : ControllerBase
	{
		private readonly CreateAppUserDetailCommandHandler _createAppUserDetailCommandHandler;
		private readonly UpdateAppUserDetailCommandHandler _updateAppUserDetailCommandHandler;
		private readonly RemoveAppUserDetailCommandHandler _removeAppUserDetailCommandHandler;
		private readonly GetAppUserDetailByIdQueryHandler _getAppUserDetailByIdQueryHandler;
		private readonly GetAppUserDetailQueryHandler _getAppUserDetailQueryHandler;
		

		public AppUserDetailController(CreateAppUserDetailCommandHandler createAppUserDetailCommandHandler, UpdateAppUserDetailCommandHandler updateAppUserDetailCommandHandler, RemoveAppUserDetailCommandHandler removeAppUserDetailCommandHandler, GetAppUserDetailByIdQueryHandler getAppUserDetailByIdQueryHandler, GetAppUserDetailQueryHandler getAppUserDetailQueryHandler)
		{
			_createAppUserDetailCommandHandler = createAppUserDetailCommandHandler;
			_updateAppUserDetailCommandHandler = updateAppUserDetailCommandHandler;
			_removeAppUserDetailCommandHandler = removeAppUserDetailCommandHandler;
			_getAppUserDetailByIdQueryHandler = getAppUserDetailByIdQueryHandler;
			_getAppUserDetailQueryHandler = getAppUserDetailQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AppUserDetailList()
		{
			var values = await _getAppUserDetailQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUserDetail(int id)
		{
			var value = await _getAppUserDetailByIdQueryHandler.Handle(new GetAppUserDetailByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAppUserDetail(CreateAppUserDetailCommand command)
		{
			await _createAppUserDetailCommandHandler.Handle(command);
			return Ok("AppUserDetail Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveAppUserDetail(int id)
		{
			await _removeAppUserDetailCommandHandler.Handle(new RemoveAppUserDetailCommand(id));
			return Ok("AppUserDetail Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAppUserDetail(UpdateAppUserDetailCommand command)
		{
			await _updateAppUserDetailCommandHandler.Handle(command);
			return Ok("AppUserDetail Güncellendi.");
		}
		
	}
}
