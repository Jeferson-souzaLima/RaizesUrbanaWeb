using Microsoft.EntityFrameworkCore;
using RaizesUrbanaWeb.Data;


var builder = WebApplication.CreateBuilder(args);

// Configura��o dos servi�os
builder.Services.AddControllersWithViews(); // Substitui AddRazorPages para usar o padr�o MVC.

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

