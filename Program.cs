using CrudUsuario.Data;
using CrudUsuario.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência do banco 
builder.Services.AddDbContext<UsuarioContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
// Fazer uma injeção de dependência sempre que a instância da minha interface for fornecida,
// A classe acompanhará junto

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
