using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramDetailsHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserExerciseProgramQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetAppUserProgramDetailsQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserExerciseProgramResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserExerciseProgramController : ControllerBase
	{
		private readonly CreateAppUserExerciseProgramCommandHandler _createAppUserExerciseProgramCommandHandler;
		private readonly UpdateAppUserExerciseProgramCommandHandler _updateAppUserExerciseProgramCommandHandler;
		private readonly RemoveAppUserExerciseProgramCommandHandler _removeAppUserExerciseProgramCommandHandler;
		private readonly GetAppUserExerciseProgramByIdQueryHandler _getAppUserExerciseProgramByIdQueryHandler;
		private readonly GetAppUserExerciseProgramQueryHandler _getAppUserExerciseProgramQueryHandler;
		private readonly GetAppUserExerciseProgramDetailsQueryHandler _getAppUserExerciseProgramDetailsQueryHandler;
		private readonly DeleteAppUserExerciseProgramByDayNoCommandHandler _deleteAppUserExerciseProgramByDayNoCommdanHandler;
		private readonly GetAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler _getAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler;

        public AppUserExerciseProgramController(CreateAppUserExerciseProgramCommandHandler createAppUserExerciseProgramCommandHandler, UpdateAppUserExerciseProgramCommandHandler updateAppUserExerciseProgramCommandHandler, RemoveAppUserExerciseProgramCommandHandler removeAppUserExerciseProgramCommandHandler, GetAppUserExerciseProgramByIdQueryHandler getAppUserExerciseProgramByIdQueryHandler, GetAppUserExerciseProgramQueryHandler getAppUserExerciseProgramQueryHandler,GetAppUserExerciseProgramDetailsQueryHandler getAppUserExerciseProgramDetailsQueryHandler, DeleteAppUserExerciseProgramByDayNoCommandHandler deleteAppUserExerciseProgramByDayNoCommandHandler, GetAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler getAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler)
		{
			_createAppUserExerciseProgramCommandHandler = createAppUserExerciseProgramCommandHandler;
			_updateAppUserExerciseProgramCommandHandler = updateAppUserExerciseProgramCommandHandler;
			_removeAppUserExerciseProgramCommandHandler = removeAppUserExerciseProgramCommandHandler;
			_getAppUserExerciseProgramByIdQueryHandler = getAppUserExerciseProgramByIdQueryHandler;
			_getAppUserExerciseProgramQueryHandler = getAppUserExerciseProgramQueryHandler;
			_getAppUserExerciseProgramDetailsQueryHandler = getAppUserExerciseProgramDetailsQueryHandler;
			_deleteAppUserExerciseProgramByDayNoCommdanHandler = deleteAppUserExerciseProgramByDayNoCommandHandler;
			_getAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler = getAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler;

        }

		[HttpGet]
		public async Task<IActionResult> AppUserExerciseProgramList()
		{
			var values = await _getAppUserExerciseProgramQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUserExerciseProgram(int id)
		{
			var value = await _getAppUserExerciseProgramByIdQueryHandler.Handle(new GetAppUserExerciseProgramByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAppUserExerciseProgram(CreateAppUserExerciseProgramCommand command)
		{
			await _createAppUserExerciseProgramCommandHandler.Handle(command);
			return Ok();
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveAppUserExerciseProgram(int id)
		{
			await _removeAppUserExerciseProgramCommandHandler.Handle(new RemoveAppUserExerciseProgramCommand(id));
			return Ok("AppUserExerciseProgram Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAppUserExerciseProgram(UpdateAppUserExerciseProgramCommand command)
		{
			await _updateAppUserExerciseProgramCommandHandler.Handle(command);
			return Ok("AppUserExerciseProgram Güncellendi.");
		}

        [HttpGet("user-exercises/{appUserId}")]
        public async Task<IActionResult> GetUserExercises(int appUserId)
        {
            var query = new GetAppUserExerciseProgramDetailsQuery(appUserId);
            var result = await _getAppUserExerciseProgramDetailsQueryHandler.Handle(query);
            return Ok(result);
        }


        [HttpDelete("delete-by-dayno/{dayNo}")]
        public async Task<IActionResult> DeleteByDayNo(int dayNo)
		{
			var command = new DeleteAppUserExerciseProgramByDayNoCommand(dayNo);
			await _deleteAppUserExerciseProgramByDayNoCommdanHandler.Handle(command);

			return NoContent();
		}
    [HttpGet("{appUserId:int}")]
        public async Task<ActionResult<List<GetAppUserExerciseProgramTotalBurnKcalQueryResult>>> GetAppUserExerciseProgramTotalBurnKcal(int appUserId)
        {
            var result = await _getAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler.Handle(new GetAppUserExerciseProgramTotalBurnKcalQuery(appUserId));
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}