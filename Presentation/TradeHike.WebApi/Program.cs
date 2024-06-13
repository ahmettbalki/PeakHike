using Microsoft.EntityFrameworkCore;
using TradeHike.Application.Interfaces;
using TradeHike.Application.Services;
using TradeHike.Persistence.Context;
using TradeHike.Persistence.Repositories;
using TradeHike.Persistence.Repositories.AppUserRepositories;
using TradeHike.Persistence.Repositories.BlogRepositories;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<MyContext>();

// Add services to the container.
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(IAppUserRepository), typeof(AppUserRepository));

builder.Services.AddApplicationService(builder.Configuration);

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