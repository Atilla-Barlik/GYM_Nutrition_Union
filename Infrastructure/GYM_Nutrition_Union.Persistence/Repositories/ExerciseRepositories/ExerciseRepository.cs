using GYM_Nurition.Domain.Dtos;
using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.ExerciseRepositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly GYM_Nutrition_Context _context;

        public ExerciseRepository(GYM_Nutrition_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseDetailWithExerciseIdDto>> GetExerciseDetailsByExerciseIdAsync(int exerciseId)
        {
            return await _context.ExerciseDetails
                             .Where(detail => detail.ExerciseId == exerciseId).Select(g=>new ExerciseDetailWithExerciseIdDto
                             {
                                 Name = g.Name,
                                 ExerciseId = g.ExerciseId,
                                 AverageKcal = g.AverageKcal,
                                 Difficulty = g.Difficulty,
                                 Equipment = g.Equipment,
                                 Description1 = g.Description1,
                                 Description2 = g.Description2,
                                 Description3 = g.Description3,
                                 ExerciseDetailId = g.ExerciseDetailId,
                                 Gif1 = g.Gif1,
                                 Gif2 = g.Gif2,
                                 Gif3 = g.Gif3,
                             })
                             .ToListAsync();
        }

    }
}
