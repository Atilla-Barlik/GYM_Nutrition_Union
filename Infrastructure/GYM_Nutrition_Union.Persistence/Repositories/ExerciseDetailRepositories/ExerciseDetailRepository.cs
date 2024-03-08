using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseDetailInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.ExerciseDetailRepositories
{
	public class ExerciseDetailRepository : IExerciseDetailRepository
	{
		private readonly GYM_Nutrition_Context _context;

		public ExerciseDetailRepository(GYM_Nutrition_Context context)
		{
			_context = context;
		}

		public  List<ExerciseDetail> GetExerciseDetailListWithExerciseNames()
		{
			var values = _context.ExerciseDetails.Include(x=>x.Exercise).ToList(); //iki tabloyu birleştirdik
			return values;
		}
	}
}
