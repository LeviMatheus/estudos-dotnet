global using Comercio.Models;
using Comercio.API.Database;
using Comercio.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureService()
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<eCommerceContext>(//injeção de dependencia para o entitty framework
    //pega a string de conexão pelo nome
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerce"))
);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();//Configurando a dependency injection para a usuario repository
#endregion

var app = builder.Build();

#region Configure()
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
#endregion