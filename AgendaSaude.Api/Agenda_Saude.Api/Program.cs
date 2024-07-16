using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AgendaSaude.Api.Infra.Data.Context;
using AgendaSaude.Api.Infra.Ioc;
using AgendaSaude.Api.Domain.Interfaces;
using AgendaSaude.Api.Infra.Data.Repositories;
using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaSaude.API", Version = "v1" });
//});

builder.Services.AddDbContext<ApplicationDbContext>(
   options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
   );

//builder.Services.AddInfrastruture(configuration);
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();



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
