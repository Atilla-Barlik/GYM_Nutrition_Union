using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserController : ControllerBase
	{
		private readonly CreateAppUserCommandHandler createAppUserCommandHandler;
		private readonly UpdateAppUserCommandHandler updateAppUserCommandHandler;
		private readonly RemoveAppUserCommandHandler removeAppUserCommandHandler;
		private readonly GetAppUserByIdQueryHandler getAppUserByIdQueryHandler;
		private readonly GetAppUserQueryHandler getAppUserQueryHandler;

		public AppUserController(CreateAppUserCommandHandler createAppUserCommandHandler, UpdateAppUserCommandHandler updateAppUserCommandHandler, RemoveAppUserCommandHandler removeAppUserCommandHandler, GetAppUserByIdQueryHandler getAppUserByIdQueryHandler, GetAppUserQueryHandler getAppUserQueryHandler)
		{
			this.createAppUserCommandHandler = createAppUserCommandHandler;
			this.updateAppUserCommandHandler = updateAppUserCommandHandler;
			this.removeAppUserCommandHandler = removeAppUserCommandHandler;
			this.getAppUserByIdQueryHandler = getAppUserByIdQueryHandler;
			this.getAppUserQueryHandler = getAppUserQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AppUserList()
		{
			var values = await getAppUserQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUser(int id)
		{
			var value = await getAppUserByIdQueryHandler.Handle(new GetAppUserByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAppUser(CreateAppUserCommand command)
		{
			await createAppUserCommandHandler.Handle(command);
			return Ok("AppUser Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveAppUser(int id)
		{
			await removeAppUserCommandHandler.Handle(new RemoveAppUserCommand(id));
			return Ok("AppUser Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAppUser(UpdateAppUserCommand command)
		{
			await updateAppUserCommandHandler.Handle(command);
			return Ok("AppUser Güncellendi.");
		}
	}
}

