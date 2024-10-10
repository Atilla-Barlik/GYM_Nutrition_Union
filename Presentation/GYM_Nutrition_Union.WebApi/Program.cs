using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyMassIndexHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramDetailsHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserTrainingTimeHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientTotalsHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientTotalsQueries;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.DailyMealTimeInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseDetailInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseInterfaces;
using GYM_Nutrition_Union.Application.Services;
using GYM_Nutrition_Union.Persistence.Context;
using GYM_Nutrition_Union.Persistence.Repositories;
using GYM_Nutrition_Union.Persistence.Repositories.AppUserExerciseProgramRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.DailyMealTimeRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.DailyNutritionRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.ExerciseDetailRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.ExerciseRepositories;
using GYM_NutritionDetails_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GYM_Nutrition_Context>();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(IDailyNutritionRepository),typeof(DailyNutritionRepository));
builder.Services.AddScoped(typeof(IExerciseDetailRepository),typeof(ExerciseDetailRepository));
builder.Services.AddScoped(typeof(IDailyMealTotalsRespository), typeof(DailyMealTotalRepository));
builder.Services.AddScoped(typeof(ITop10UsageNutritionRepository), typeof(Top10UsageNutritionRepository));
builder.Services.AddScoped(typeof(IUserTop10UsageNutrientRepository), typeof(UserTop10UsageNutrientRepository));
builder.Services.AddScoped(typeof(IExerciseRepository), typeof(ExerciseRepository));
builder.Services.AddScoped(typeof(IAppUserExerciseProgramRespository), typeof(AppUserExerciseProgramRespository));

builder.Services.AddScoped<GetExerciseByIdQueryHandler>();
builder.Services.AddScoped<GetExerciseQueryHandler>();
builder.Services.AddScoped<RemoveExerciseCommandHandler>();
builder.Services.AddScoped<UpdateExerciseCommandHandle>();
builder.Services.AddScoped<CreateExerciseCommandHandler>();

builder.Services.AddScoped<GetExerciseDetailByIdQueryHandler>();
builder.Services.AddScoped<GetExerciseDetailQueryHandler>();
builder.Services.AddScoped<RemoveExerciseDetailCommandHandler>();
builder.Services.AddScoped<UpdateExerciseDetailCommandHandler>();
builder.Services.AddScoped<CreateExerciseDetailCommandHandler>();
builder.Services.AddScoped<GetExerciseDetailWithExerciseNameQueryHandler>();

builder.Services.AddScoped<GetAppUserByIdQueryHandler>();
builder.Services.AddScoped<GetAppUserQueryHandler>();
builder.Services.AddScoped<RemoveAppUserCommandHandler>();
builder.Services.AddScoped<UpdateAppUserCommandHandler>();
builder.Services.AddScoped<CreateAppUserCommandHandler>();

builder.Services.AddScoped<GetAppUserDetailByIdQueryHandler>();
builder.Services.AddScoped<GetAppUserDetailQueryHandler>();
builder.Services.AddScoped<RemoveAppUserDetailCommandHandler>();
builder.Services.AddScoped<UpdateAppUserDetailCommandHandler>();
builder.Services.AddScoped<CreateAppUserDetailCommandHandler>();

builder.Services.AddScoped<GetAppUserBodyDetailByIdQueryHandler>();
builder.Services.AddScoped<GetAppUserBodyDetailQueryHandler>();
builder.Services.AddScoped<RemoveAppUserBodyDetailCommandHandler>();
builder.Services.AddScoped<UpdateAppUserBodyDetailCommandHandler>();
builder.Services.AddScoped<CreateAppUserBodyDetailCommandHandler>();

builder.Services.AddScoped<GetAppUserBodyMassIndexByIdQueryHandler>();
builder.Services.AddScoped<GetAppUserBodyMassIndexQueryHandler>();
builder.Services.AddScoped<RemoveAppUserBodyMassIndexCommandHandler>();
builder.Services.AddScoped<UpdateAppUserBodyMassIndexCommandHandler>();
builder.Services.AddScoped<CreateAppUserBodyMassIndexCommandHandler>();

builder.Services.AddScoped<GetAppUserExerciseProgramByIdQueryHandler>();
builder.Services.AddScoped<GetAppUserExerciseProgramQueryHandler>();
builder.Services.AddScoped<RemoveAppUserExerciseProgramCommandHandler>();
builder.Services.AddScoped<UpdateAppUserExerciseProgramCommandHandler>();
builder.Services.AddScoped<CreateAppUserExerciseProgramCommandHandler>();

builder.Services.AddScoped<GetAppUserTrainingTimeByIdQueryHandler>();
builder.Services.AddScoped<GetAppUserTrainingTimeQueryHandler>();
builder.Services.AddScoped<RemoveAppUserTrainingTimeCommandHandler>();
builder.Services.AddScoped<UpdateAppUserTrainingTimeCommandHandler>();
builder.Services.AddScoped<CreateAppUserTrainingTimeCommandHandler>();

builder.Services.AddScoped<GetDailyNutrientByIdQueryHandler>();
builder.Services.AddScoped<GetDailyNutritionQueryHandler>();
builder.Services.AddScoped<RemoveDailyNutritionCommandHandler>();
builder.Services.AddScoped<UpdateDailyNutritionCommandHandler>();
builder.Services.AddScoped<CreateDailyNutritionCommandHandler>();

builder.Services.AddScoped<GetDailyNutritionDetailByIdQueryHandler>();
builder.Services.AddScoped<GetDailyNutritionDetailQueryHandler>();
builder.Services.AddScoped<RemoveDailyNutritionDetailCommandHandler>();
builder.Services.AddScoped<UpdateDailyNutritionDetailCommandHandler>();
builder.Services.AddScoped<CreateDailyNutritionDetailCommandHandler>();

builder.Services.AddScoped<GetNutrientByIdQueryHandler>();
builder.Services.AddScoped<GetNutrientQueryHandler>();
builder.Services.AddScoped<RemoveNutrientCommandHandler>();
builder.Services.AddScoped<UpdateNutrientCommandHandler>();
builder.Services.AddScoped<CreateNutrientCommandHandler>();

builder.Services.AddScoped<GetDailyNutritionByUserIdAndDateQueryHandler>();

builder.Services.AddScoped<GetNutrientTotalsHandler>();

builder.Services.AddScoped<GetTop10NutrientsQueryHandler>();

builder.Services.AddScoped<GetUserMostUsedNutrientsQueryHandler>();

builder.Services.AddScoped<GetExerciseDetailsWithExerciseIdQueryHandler>();

builder.Services.AddScoped<GetAppUserExerciseProgramDetailsQueryHandler>();

builder.Services.AddScoped<DeleteAppUserExerciseProgramByDayNoCommandHandler>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.MaxDepth = 64; // Veya ihtiyacýnýza göre daha yüksek bir deðer
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
