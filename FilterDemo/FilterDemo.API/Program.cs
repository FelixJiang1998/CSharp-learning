using FilterDemo.API.Filters;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register order: Global > Class > Method 
builder.Services.AddControllers(o =>
{
    // We can still manually specify the priority of every filter. 1 is the highest
    o.Filters.Add<CtmActionFilterAttribute>();
});

// 注册缓存, 应使用单例确保数据共享
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();


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