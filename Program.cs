using Dashboard.DataAccess.Data;
using Dashboard.DataAccess.Entities;
using Dashboard.Endpoints;
using Dashboard.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IValidator<Movie>, MovieValidator>();
//TODO add validator by assembly
builder.Services.AddDbContext<DashboardDbContext>(opt => opt.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));



var app = builder.Build();

app.MapMovieEndpoints();


app.UseHttpsRedirection();



app.Run();


