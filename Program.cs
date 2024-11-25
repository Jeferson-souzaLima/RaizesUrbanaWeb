using Microsoft.EntityFrameworkCore;
using RaizesUrbanaWeb.Data;
using RaizesUrbanaWeb.Services; // Importando o namespace do UserService


var builder = WebApplication.CreateBuilder(args);

// Configura��o dos servi�os
builder.Services.AddControllersWithViews(); // Substitui AddRazorPages para usar o padr�o MVC.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configura��o do contexto de dados com a string de conex�o.

builder.Services.AddScoped<UserService>(); // Registrando o UserService para inje��o de depend�ncia

var app = builder.Build();

// Configura��o do pipeline de requisi��es
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configura��o de rotas para o MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Se precisar de rotas adicionais, elas podem ser configuradas aqui.

app.Run();

