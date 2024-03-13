using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserBodyMassIndexHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.AppUserHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseDetailHandler;
using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Application.Interfaces.ExerciseDetailInterfaces;
using GYM_Nutrition_Union.Persistence.Context;
using GYM_Nutrition_Union.Persistence.Repositories;
using GYM_Nutrition_Union.Persistence.Repositories.ExerciseDetailRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GYM_Nutrition_Context>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(IExerciseDetailRepository),typeof(ExerciseDetailRepository));
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
