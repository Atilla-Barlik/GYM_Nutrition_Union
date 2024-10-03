using GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExercisesController : ControllerBase
	{
		private readonly CreateExerciseCommandHandler _createExerciseCommandHandler;
		private readonly UpdateExerciseCommandHandle _updateExerciseCommandHandler;
		private readonly RemoveExerciseCommandHandler _removeExerciseCommandHandler;
		private readonly GetExerciseByIdQueryHandler _getExerciseByIdQueryHandler;
		private readonly GetExerciseQueryHandler _getExerciseQueryHandler;
		

		public ExercisesController(CreateExerciseCommandHandler createExerciseCommandHandler, UpdateExerciseCommandHandle updateExerciseCommandHandler, RemoveExerciseCommandHandler removeExerciseCommandHandler, GetExerciseByIdQueryHandler getExerciseByIdQueryHandler, GetExerciseQueryHandler getExerciseQueryHandler)
		{
			_createExerciseCommandHandler = createExerciseCommandHandler;
			_updateExerciseCommandHandler = updateExerciseCommandHandler;
			_removeExerciseCommandHandler = removeExerciseCommandHandler;
			_getExerciseByIdQueryHandler = getExerciseByIdQueryHandler;
			_getExerciseQueryHandler = getExerciseQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> ExerciseList()
		{
			var values = await _getExerciseQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetExercise(int id)
		{
			var value = await _getExerciseByIdQueryHandler.Handle(new GetExerciseByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateExercise(CreateExerciseCommand command)
		{
			await _createExerciseCommandHandler.Handle(command);
			return Ok("Egzersiz Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveExercise(int id)
		{
			await _removeExerciseCommandHandler.Handle(new RemoveExerciseCommand(id));
			return Ok("Egzersiz Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateExercise(UpdateExerciseCommand command)
		{
			await _updateExerciseCommandHandler.Handle(command);
			return Ok("Egzersiz Güncellendi.");
		}

		
	}
}
