using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyMacroCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DailyNutritionDetailCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyMacroQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.DailyNutritionDetailQueries;
using GYM_NutritionDetails_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMacroController : ControllerBase
    {
        private readonly CreateDailyMacroCommandHandler _createDailyMacroCommandHandler;
        private readonly UpdateDailyMacroCommandHandler _updateDailyMacroCommandHandler;
        private readonly RemoveDailyMacroCommandHandler _removeDailyMacroCommandHandler;
        private readonly GetDailyMacroByIdQueryHandler _getDailyMacroByIdQueryHandler;
        private readonly GetDailyMacroQueryHandler _getDailyMacroQueryHandler;
        private readonly GetLatestDailyMacroByUserIdQueryHandler _getLatestDailyMacroByUserIdQueryHandler;

        public DailyMacroController(CreateDailyMacroCommandHandler createDailyMacroCommandHandler, UpdateDailyMacroCommandHandler updateDailyMacroCommandHandler, RemoveDailyMacroCommandHandler removeDailyMacroCommandHandler, GetDailyMacroByIdQueryHandler getDailyMacroByIdQueryHandler, GetDailyMacroQueryHandler getDailyMacroQueryHandler,
            GetLatestDailyMacroByUserIdQueryHandler getLatestDailyMacroByUserIdQueryHandler)
        {
            _createDailyMacroCommandHandler = createDailyMacroCommandHandler;
            _updateDailyMacroCommandHandler = updateDailyMacroCommandHandler;
            _removeDailyMacroCommandHandler = removeDailyMacroCommandHandler;
            _getDailyMacroByIdQueryHandler = getDailyMacroByIdQueryHandler;
            _getDailyMacroQueryHandler = getDailyMacroQueryHandler;
            _getLatestDailyMacroByUserIdQueryHandler = getLatestDailyMacroByUserIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> DailyMacroList()
        {
            var values = await _getDailyMacroQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDailyMacroById(int id)
        {
            var value = await _getDailyMacroByIdQueryHandler.Handle(new GetDailyMacroByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDailyMacro(CreateDailyMacroCommand command)
        {
            await _createDailyMacroCommandHandler.Handle(command);
            return Ok("DailyMacro Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDailyMacro(int id)
        {
            await _removeDailyMacroCommandHandler.Handle(new RemoveDailyMacroCommand(id));
            return Ok("DailyMacro  Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDailyMacro(UpdateDailyMacroCommand command)
        {
            await _updateDailyMacroCommandHandler.Handle(command);
            return Ok("DailyMacro  Güncellendi.");
        }

        [HttpGet("latest/{appUserId}")]
        public async Task<IActionResult> GetLatestMacro(int appUserId)
        {
            var result = await _getLatestDailyMacroByUserIdQueryHandler.Handle(new GetLatestDailyMacroByUserIdQuery(appUserId));

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
