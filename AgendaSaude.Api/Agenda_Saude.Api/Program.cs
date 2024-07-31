using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AgendaSaude.Api.Infra.Data.Context;
using AgendaSaude.Api.Infra.Ioc;
using AgendaSaude.Api.Domain.Interfaces;
using AgendaSaude.Api.Infra.Data.Repositories;
using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Swagger
builder.Services.AddInfrastructureSwagger();

//builder.Services.AddAuthentication(opition =>
//{
//    opition.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opition.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}
//).AddJwtBearer(opt =>
//{
//    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,

//        IssuerSigningKey = builder.Configuration["jwt: SecretKey"],
//    };
//});
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaSaude.API", Version = "v1" });
//});

//Conexão Data Base
builder.Services.AddDbContext<ApplicationDbContext>(
   options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
   );

//builder.Services.ConfigureJwt(builder.Configuration);

//builder.Services.AddInfrastruture(configuration);

//Repository
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

//Services
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IPacienteServices, PacienteServeces>();



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
