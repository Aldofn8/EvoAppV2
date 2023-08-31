using EvoApp.Services;
using EvoApp.Services.Articles;
using EvoApp.Services.Contract;
using EvoApp.Services.Details;
using FluentValidation;
using FluentValidation.AspNetCore;
using MySql.Data.MySqlClient;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IArticlesServiceRest, ArticlesServiceRest>();
builder.Services.AddScoped<IContractServiceRest, ContractServiceRest>();
builder.Services.AddScoped<IDetailsServiceRest, DetailsServiceRest>();

builder.Services.AddCors(options => {
    options.AddPolicy("Default", builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

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
