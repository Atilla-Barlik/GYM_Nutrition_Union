using GYM_Nurition.Domain.Dtos;
using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler
{
    public class GetExerciseDetailsWithExerciseIdQueryHandler
    {
        private readonly IExerciseRepository _exerciseRepository;

        public GetExerciseDetailsWithExerciseIdQueryHandler(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<IEnumerable<ExerciseDetailWithExerciseIdDto>> Handle(int id)
        {
            return await _exerciseRepository.GetExerciseDetailsByExerciseIdAsync(id);
        }
    }

    public class GetExerciseDetailsQuery
    {

        public int ExerciseId { get; set; }
        public GetExerciseDetailsQuery(int exerciseId)
        {
            ExerciseId = exerciseId;
        }

    }
}
