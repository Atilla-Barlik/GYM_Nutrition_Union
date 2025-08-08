using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyMassIndexHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramDetailsHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserExerciseProgramHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserTrainingTimeHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AvgKcalDailyHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyMacroHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.DailyNutritionHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.NutrientTotalsHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientTotalsQueries;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Application.Interfaces.AppUserDetailInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.AppUserExerciseProgramInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.AppUserInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.AvgKcalDailyInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.DailyMacroInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.DailyMealTimeInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionDetailInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.DailyNutritionInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseDetailInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.JWTokenInterfaces;
using GYM_Nutrition_Union.Application.Interfaces.NutrientInterfaces;
using GYM_Nutrition_Union.Application.Services;
using GYM_Nutrition_Union.Persistence.Context;
using GYM_Nutrition_Union.Persistence.Repositories;
using GYM_Nutrition_Union.Persistence.Repositories.AppUserDetailRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.AppUserExerciseProgramRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.AppUserExerciseStatisticsRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.AppUserRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.AvgKcalDailyRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.DailyMacroRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.DailyMealTimeRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.DailyNutritionDetailRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.DailyNutritionRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.ExerciseDetailRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.ExerciseRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.JWTokenRepositories;
using GYM_Nutrition_Union.Persistence.Repositories.NutrientRepositories;
using GYM_NutritionDetails_Union.Application.Features.CQRS.Handlers.DailyNutritionDetailHandler;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
builder.Services.AddScoped(typeof(INutrientRepository), typeof(NutrientRepository));
builder.Services.AddScoped(typeof(IAppUserDetailRepository), typeof(AppUserDetailRepository));
builder.Services.AddScoped(typeof(IAppUserExerciseStatisticsRepository), typeof(AppUserExerciseStatisticsRepository));
builder.Services.AddScoped(typeof(IDailyNutritionDetailGetByUserIdRepository), typeof(DailyNutritionDetailGetByUserIdRepository));
builder.Services.AddScoped(typeof(IDailyMacroRepository), typeof(DailyMacroRepository));
builder.Services.AddScoped(typeof(IDailyNutritionTotalsRepository), typeof(DailyNutritionTotalsRepository));
builder.Services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
builder.Services.AddScoped(typeof(IAppUserRepository), typeof(AppUserRepository));
builder.Services.AddScoped(typeof(IDailyNutritionGetClosedByUserRepository), typeof(DailyNutritionGetClosedByUserRepository));
builder.Services.AddScoped(typeof(IAvgKcalDailyRepository), typeof(AvgKcalDailyRepository));

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
builder.Services.AddScoped<GetAppUserExerciseProgramTotalBurnKcalByUserIdQueryHandler>();

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
builder.Services.AddScoped<GetAppUserDetailByUserIdQueryHandler>();

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
builder.Services.AddScoped<CloseDailyNutritionCommandHandler>();
builder.Services.AddScoped<GetClosedDailyNutritionByUserQueryHandler>();

builder.Services.AddScoped<GetDailyNutritionDetailByIdQueryHandler>();
builder.Services.AddScoped<GetDailyNutritionDetailQueryHandler>();
builder.Services.AddScoped<RemoveDailyNutritionDetailCommandHandler>();
builder.Services.AddScoped<UpdateDailyNutritionDetailCommandHandler>();
builder.Services.AddScoped<CreateDailyNutritionDetailCommandHandler>();
builder.Services.AddScoped<GetLatestNutritionDetailsByUserIdQueryHandler>();

builder.Services.AddScoped<GetNutrientByIdQueryHandler>();
builder.Services.AddScoped<GetNutrientQueryHandler>();
builder.Services.AddScoped<RemoveNutrientCommandHandler>();
builder.Services.AddScoped<UpdateNutrientCommandHandler>();
builder.Services.AddScoped<CreateNutrientCommandHandler>();

builder.Services.AddScoped<CreateDailyMacroCommandHandler>();
builder.Services.AddScoped<RemoveDailyMacroCommandHandler>();
builder.Services.AddScoped<UpdateDailyMacroCommandHandler>();
builder.Services.AddScoped<GetDailyMacroByIdQueryHandler>();
builder.Services.AddScoped<GetDailyMacroQueryHandler>();
builder.Services.AddScoped<GetLatestDailyMacroByUserIdQueryHandler>();

builder.Services.AddScoped<CreateAvgKcalDailyCommandHandler>();
builder.Services.AddScoped<GetAvgKcalDailyQueryHandler>();
builder.Services.AddScoped<GetLatestAvgKcalDailyByUserIdQueryHandler>();

builder.Services.AddScoped<GetDailyNutritionByUserIdAndDateQueryHandler>();

builder.Services.AddScoped<GetNutrientTotalsHandler>();

builder.Services.AddScoped<GetTop10NutrientsQueryHandler>();

builder.Services.AddScoped<GetUserMostUsedNutrientsQueryHandler>();

builder.Services.AddScoped<GetExerciseDetailsWithExerciseIdQueryHandler>();

builder.Services.AddScoped<GetAppUserExerciseProgramDetailsQueryHandler>();

builder.Services.AddScoped<DeleteAppUserExerciseProgramByDayNoCommandHandler>();

builder.Services.AddScoped<GetNutrientByNameQueryHandler>();

builder.Services.AddScoped<GetUserExerciseStatisticsQueryHandler>();

builder.Services.AddScoped<AuthenticateUserQueryHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.MaxDepth = 64; // Veya ihtiyacýnýza göre daha yüksek bir deðer
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddScoped<IJwtTokenInterface, JwtTokenInterface>();
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey!)
        )
    };
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
