using Microsoft.EntityFrameworkCore;
using RaizesUrbanaWeb.Data;


var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.AddControllersWithViews(); // Substitui AddRazorPages para usar o padrão MVC.

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

