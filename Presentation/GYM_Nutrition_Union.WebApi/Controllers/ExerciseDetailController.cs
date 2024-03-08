using GYM_Nutrition_Union.Application.Features.CQRS.Commands.ExerciseDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseDetailQueries;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExerciseDetailController : ControllerBase
	{
		private readonly CreateExerciseDetailCommandHandler _createExerciseDetailCommandHandler;
		private readonly UpdateExerciseDetailCommandHandler _updateExerciseDetailCommandHandler;
		private readonly RemoveExerciseDetailCommandHandler _removeExerciseDetailCommandHandler;
		private readonly GetExerciseDetailByIdQueryHandler _getExerciseDetailByIdQueryHandler;
		private readonly GetExerciseDetailQueryHandler _getExerciseDetailQueryHandler;
		private readonly GetExerciseDetailWithExerciseNameQueryHandler _getByExerciseNameQueryHandler;

		public ExerciseDetailController(CreateExerciseDetailCommandHandler createExerciseDetailCommandHandler, UpdateExerciseDetailCommandHandler updateExerciseDetailCommandHandler, RemoveExerciseDetailCommandHandler removeExerciseDetailCommandHandler, GetExerciseDetailByIdQueryHandler getExerciseDetailByIdQueryHandler, GetExerciseDetailQueryHandler getExerciseDetailQueryHandler, GetExerciseDetailWithExerciseNameQueryHandler getByExerciseNameQueryHandler)
		{
			_createExerciseDetailCommandHandler = createExerciseDetailCommandHandler;
			_updateExerciseDetailCommandHandler = updateExerciseDetailCommandHandler;
			_removeExerciseDetailCommandHandler = removeExerciseDetailCommandHandler;
			_getExerciseDetailByIdQueryHandler = getExerciseDetailByIdQueryHandler;
			_getExerciseDetailQueryHandler = getExerciseDetailQueryHandler;
			_getByExerciseNameQueryHandler = getByExerciseNameQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> ExerciseDetailList()
		{
			var values = await _getExerciseDetailQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetExerciseDetail(int id)
		{
			var value = await _getExerciseDetailByIdQueryHandler.Handle(new GetExerciseDetailByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateExerciseDetail(CreateExerciseDetailCommand command)
		{
			await _createExerciseDetailCommandHandler.Handle(command);
			return Ok("Egzersiz Eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveExerciseDetail(int id)
		{
			await _removeExerciseDetailCommandHandler.Handle(new RemoveExerciseDetailCommand(id));
			return Ok("Egzersiz Silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateExerciseDetail(UpdateExerciseDetailCommand command)
		{
			await _updateExerciseDetailCommandHandler.Handle(command);
			return Ok("Egzersiz Güncellendi.");
		}
		[HttpGet("GetExerciseDetailWithExerciseName")]
		public IActionResult GetExerciseDetailWithExerciseName()
		{
			var values = _getByExerciseNameQueryHandler.Handle();
			return Ok(values);
		}
	}
}
