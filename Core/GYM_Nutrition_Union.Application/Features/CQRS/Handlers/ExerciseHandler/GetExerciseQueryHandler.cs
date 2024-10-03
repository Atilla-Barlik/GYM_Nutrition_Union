using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.ExerciseResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler
{
	public class GetExerciseQueryHandler
	{
		private readonly IRepository<Exercise> _repository;

		public GetExerciseQueryHandler(IRepository<Exercise> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetExerciseQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetExerciseQueryResult
			{
				ExerciseId = x.ExerciseId,
				ExerciseName = x.ExerciseName,
				ExerciseImage = x.ExerciseImage
			}).ToList();
		}
	}
}
