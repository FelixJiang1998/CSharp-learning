using EFCoreDemo.API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// WARNING: should use Scoped!!
// Singleton trap: can result in service's breaking down
// 1. if not released, context as singleton can only track one entity with the same ID 
// 2. cannot handle multiple visit of different methods at the same time
builder.Services.AddSingleton<JobRecruitmentContext>();

builder.Services.AddCors(c => c.AddPolicy("any",
        p =>
            p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();