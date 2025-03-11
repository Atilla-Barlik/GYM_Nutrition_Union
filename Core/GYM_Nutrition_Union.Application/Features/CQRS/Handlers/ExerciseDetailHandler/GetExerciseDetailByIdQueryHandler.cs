using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseDetailQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.ExerciseQueries;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.ExerciseDetailResults;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.ExerciseResults;
using GYM_Nutrition_Union.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseDetailHandler
{
	public class GetExerciseDetailByIdQueryHandler
	{
		private readonly IRepository<ExerciseDetail> _repository;

		public GetExerciseDetailByIdQueryHandler(IRepository<ExerciseDetail> repository)
		{
			_repository = repository;
		}

		public async Task<GetExerciseDetailByIdQueryResult> Handle(GetExerciseDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetExerciseDetailByIdQueryResult
			{
				ExerciseDetailId = values.ExerciseDetailId,
				Name = values.Name,
				AverageKcal = values.AverageKcal,
				Difficulty = values.Difficulty,
				Equipment = values.Equipment,
				Description1 = values.Description1,
				Description2 = values.Description2,
				Description3 = values.Description3,
				Description4 = values.Description4,
				Gif1 = values.Gif1,
				Gif2 = values.Gif2,
				Gif3 = values.Gif3,
				BaseMET = values.BaseMET,
				ExerciseId = values.ExerciseId
			};
		}
	}
}
