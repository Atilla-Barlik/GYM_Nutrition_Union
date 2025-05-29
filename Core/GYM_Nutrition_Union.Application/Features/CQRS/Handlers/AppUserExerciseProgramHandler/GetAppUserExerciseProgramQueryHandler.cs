using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Results.AppUserExerciseProgramResults;
using GYM_Nutrition_Union.Application.Interfaces;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler
{
	public class GetAppUserExerciseProgramQueryHandler
	{
		private readonly IRepository<AppUserExerciseProgram> _repository;

		public GetAppUserExerciseProgramQueryHandler(IRepository<AppUserExerciseProgram> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppUserExerciseProgramQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppUserExerciseProgramQueryResult
			{
				AppUserExerciseProgramId = x.AppUserExerciseProgramId,
				AppUserId = x.AppUserId,
				ExerciseDetailId = x.ExerciseDetailId,
				ExerciseRepeat = x.ExerciseRepeat,
				ExerciseSet = x.ExerciseSet,
                ExerciseWeight = x.ExerciseWeight,
				ExerciseDone = x.ExerciseDone,
                ExerciseTotalBurnedKcal = x.ExerciseTotalBurnedKcal,
				DayNo = x.DayNo,
				Date = x.Date,
			}).ToList();
		}
	}
}
