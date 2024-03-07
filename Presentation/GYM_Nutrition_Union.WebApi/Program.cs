using GYM_Nutrition_Union.Application.Features.CQRS.Handlers.ExerciseHandler;
using GYM_Nutrition_Union.Application.Interfaces;
using GYM_Nutrition_Union.Persistence.Context;
using GYM_Nutrition_Union.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GYM_Nutrition_Context>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<GetExerciseByIdQueryHandler>();
builder.Services.AddScoped<GetExerciseQueryHandler>();
builder.Services.AddScoped<RemoveExerciseCommandHandler>();
builder.Services.AddScoped<UpdateExerciseCommandHandle>();
builder.Services.AddScoped<CreateExerciseCommandHandler>();

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
