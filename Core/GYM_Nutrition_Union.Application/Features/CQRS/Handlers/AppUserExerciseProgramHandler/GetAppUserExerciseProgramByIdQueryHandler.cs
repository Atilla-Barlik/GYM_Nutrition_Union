using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserExerciseProgramQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserExerciseProgramResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler
{
	public class GetAppUserExerciseProgramByIdQueryHandler
	{
		private readonly IRepository<AppUserExerciseProgram> _repository;

		public GetAppUserExerciseProgramByIdQueryHandler(IRepository<AppUserExerciseProgram> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppUserExerciseProgramByIdQueryResult> Handle(GetAppUserExerciseProgramByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAppUserExerciseProgramByIdQueryResult
			{
				AppUserExerciseProgramId = values.AppUserExerciseProgramId,
				AppUserId = values.AppUserId,
				ExerciseDetailId = values.ExerciseDetailId,
				ExerciseRepeat = values.ExerciseRepeat,
				ExerciseSet = values.ExerciseSet,
				ExerciseWeight = values.ExerciseWeight,
				ExerciseTotalBurnedKcal = values.ExerciseTotalBurnedKcal,
				DayNo = values.DayNo,
				Date = values.Date,
			};
		}
	}
}
