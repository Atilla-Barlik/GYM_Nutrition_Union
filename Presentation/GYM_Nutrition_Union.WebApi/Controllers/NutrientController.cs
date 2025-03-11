using GYM_Nutrition_Union.Application.Features.CQRS.Commands.DaillyNutritionCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.NutrientCommands;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetDailyNutritionQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GYM_Nutrition_Union.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutrientController : ControllerBase
    {
        private readonly CreateNutrientCommandHandler _createCommandHandler;
        private readonly UpdateNutrientCommandHandler? _updateCommandHandler;
        private readonly RemoveNutrientCommandHandler _removeCommendHandler;
        private readonly GetNutrientByIdQueryHandler _getNutrientByIdQueryHandler;
        private readonly GetNutrientQueryHandler _getNutrientQueryHandler;
        private readonly GetNutrientByNameQueryHandler _getNutrientByNameQueryHandler;

        public NutrientController(CreateNutrientCommandHandler commandHandler, UpdateNutrientCommandHandler? updateCommandHandler, RemoveNutrientCommandHandler removeCommendHandler, GetNutrientByIdQueryHandler getNutrientByIdQueryHandler, GetNutrientQueryHandler getNutrientQueryHandler, GetNutrientByNameQueryHandler getNutrientByNameQueryHandler)
        {
            _createCommandHandler = commandHandler;
            _updateCommandHandler = updateCommandHandler;
            _removeCommendHandler = removeCommendHandler;
            _getNutrientByIdQueryHandler = getNutrientByIdQueryHandler;
            _getNutrientQueryHandler = getNutrientQueryHandler;
            _getNutrientByNameQueryHandler = getNutrientByNameQueryHandler;
            
        }

        [HttpGet]
        public async Task<IActionResult> DailyNutritionList()
        {
            var values = await _getNutrientQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDailyNutrition(int id)
        {
            var value = await _getNutrientByIdQueryHandler.Handle(new GetNutrientByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDailyNutrition(CreateNutrientCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("Egzersiz Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDailyNutrition(int id)
        {
            await _removeCommendHandler.Handle(new RemoveNutrientCommand(id));
            return Ok("Egzersiz Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDailyNutrition(UpdateNutrientCommand command)
        {
            await _updateCommandHandler.Handle(command);
            return Ok("Egzersiz Güncellendi.");
        }
        [HttpGet("GetNutrientDetailByName/{name}")]
        public async Task<IActionResult> GetNutrientDetailByName(string name)
        {
            var result = await _getNutrientByNameQueryHandler.Handle(new GetNutrientByNameQuery(name));
            if (result == null)
                return NotFound("Besin bulunamadı!");

            return Ok(result);
        }
    }
}
