using GYM_Nurition.Domain.Entities;
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
	public class GetExerciseDetailQueryHandler
	{
		private readonly IRepository<ExerciseDetail> _repository;

		public GetExerciseDetailQueryHandler(IRepository<ExerciseDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetExerciseDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetExerciseDetailQueryResult
			{
				ExerciseDetailId = x.ExerciseDetailId,
				Name = x.Name,
				AverageKcal = x.AverageKcal,
				Difficulty = x.Difficulty,
				Equipment = x.Equipment,
				Description1 = x.Description1,
				Description2 = x.Description2,
				Description3 = x.Description3,
				Description4 = x.Description4,
				Gif1 = x.Gif1,
				Gif2 = x.Gif2,
				Gif3 = x.Gif3,
				ExerciseId = x.ExerciseId
			}).ToList();
		}
	}
}
