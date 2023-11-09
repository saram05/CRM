using CRM.API.Data;
using CRM.API.Helpers;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyectamos la base de datos
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Name=CadenaConexion");
});
//Existen 3 maneras de inyectar servicios en el program:
// 1 builder.Services.AddSingleton - Es cuando el objeto permanecen en memoria todo el tiempo
// 2 builder.Services.AddScoped - Es cada que se necesita inyecta un nuevo objeto
// 3 builder.Services.AddTransient - Lo inyecta una sola vez y nunca mas.
builder.Services.AddTransient<SeedDb>();

//inyectamos el centralizador de usuarios
builder.Services.AddScoped<IUserHelper, UserHelper>();

builder.Services.AddIdentity<Users, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
