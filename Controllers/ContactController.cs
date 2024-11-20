using Microsoft.AspNetCore.Mvc;
using RaizesUrbanaWeb.Models;

namespace RaizesUrbanaWeb.Controllers
{
    public class ContatoController : Controller
    {
        // Exibe o formulário de contato
        public IActionResult Index()
        {
            return View();
        }

        // Recebe os dados do formulário de contato e processa a requisição
        [HttpPost]
        public IActionResult EnviarContato(Contact model)
        {
            if (ModelState.IsValid)
            {
                // Aqui você pode processar os dados do formulário
                // Como enviar um e-mail ou salvar no banco de dados, etc.

                // Exemplo: Enviar um e-mail
                // EnviarEmail(model);

                // Ou apenas mostrar uma mensagem de sucesso
                TempData["SuccessMessage"] = "Mensagem enviada com sucesso!";
                return RedirectToAction("Index");
            }
            else
            {
                // Se houver erros de validação, exibe novamente o formulário
                return View("Index", model);
            }
        }
    }
}
