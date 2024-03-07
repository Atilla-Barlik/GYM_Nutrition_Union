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
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;initial Catalog=GYM_Nutrition_Union_Api;integrated Security=true;TrustServerCertificate=true");
		}
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseDetail> ExerciseDetails{ get; set; }
	}
}
