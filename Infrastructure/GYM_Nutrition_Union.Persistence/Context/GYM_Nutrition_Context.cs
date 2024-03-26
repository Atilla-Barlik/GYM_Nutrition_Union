using GYM_Nurition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Context
{
	public class GYM_Nutrition_Context :DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-HQOU69I;initial Catalog=GYM_Nutrition_Union_Api;integrated Security=true;TrustServerCertificate=true");
		}
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseDetail> ExerciseDetails{ get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<AppUserDetail> AppUsersDetail { get; set; }
		public DbSet<AppUserBodyDetail> AppUsersBodyDetail { get; set;}
		public DbSet<AppUserBodyMassIndex> AppUsersBodyMassIndex { get; set; }
		public DbSet<AppUserExerciseProgram> AppUsersExerciseProgram { get; set; }
		public DbSet<AppUserTrainingTime> AppUsersTrainingTime { get; set;}
		public DbSet<DailyNutrition> DailyNutrition { get; set; }
		public DbSet<DailyNutritionDetails> DailyNutritionDetails { get; set; }	
		
	}
}
