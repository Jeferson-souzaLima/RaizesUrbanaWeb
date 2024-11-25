using Microsoft.EntityFrameworkCore;
using RaizesUrbanaWeb.Data;
using RaizesUrbanaWeb.Services; // Importando o namespace do UserService


var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.AddControllersWithViews(); // Substitui AddRazorPages para usar o padrão MVC.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configuração do contexto de dados com a string de conexão.

builder.Services.AddScoped<UserService>(); // Registrando o UserService para injeção de dependência

var app = builder.Build();

// Configuração do pipeline de requisições
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuração de rotas para o MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Se precisar de rotas adicionais, elas podem ser configuradas aqui.

app.Run();

