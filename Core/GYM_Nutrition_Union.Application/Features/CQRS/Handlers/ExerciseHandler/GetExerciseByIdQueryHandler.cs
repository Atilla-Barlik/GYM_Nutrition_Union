using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.ExerciseResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler
{
	public class GetExerciseByIdQueryHandler
	{
		private readonly IRepository<Exercise> _repository;

		public GetExerciseByIdQueryHandler(IRepository<Exercise> repository)
		{
			_repository = repository;
		}

		public async Task<GetExerciseByIdQueryResult> Handle(GetExerciseByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetExerciseByIdQueryResult
			{
				ExerciseId = values.ExerciseId,
				ExerciseName = values.ExerciseName,
				ExerciseImage = values.ExerciseImage,
			};
		}
	}
}
