using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserExerciseProgramCommands;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler
{
	public class RemoveAppUserExerciseProgramCommandHandler
	{
		private readonly IRepository<AppUserExerciseProgram> _repository;

		public RemoveAppUserExerciseProgramCommandHandler(IRepository<AppUserExerciseProgram> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAppUserExerciseProgramCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
