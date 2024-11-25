using Microsoft.AspNetCore.Mvc;
using RaizesUrbanaWeb.Models;
using RaizesUrbanaWeb.Services;
using RaizesUrbanaWeb.Data; // Para o contexto do banco
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RaizesUrbanaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;
        private readonly ApplicationDbContext _context;

        // Injeção de dependência dos serviços
        public HomeController(UserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        // Exibição da página inicial
        public IActionResult Index()
        {
            return View();
        }

        // Exibição da página Sobre Nós
        public IActionResult SobreNos()
        {
            return View();
        }

        // Exibição da página Entregas
        public IActionResult Entregas()
        {
            return View();
        }

        // Exibição da página de Contato
        public IActionResult Contact()
        {
            return View();
        }

        // Exibição da página de Privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // Exibição da página de Produtos
        public IActionResult Produtos()
        {
            return View();
        }

        // Método para cadastro de usuário
        [HttpPost]
        public async Task<IActionResult> Cadastrar(string nome, string email, string senha, string confirmarSenha)
        {
            if (senha != confirmarSenha)
            {
                ModelState.AddModelError("senha", "As senhas não coincidem.");
                TempData["MensagemErro"] = "As senhas não coincidem!";
                return RedirectToAction("Index");
            }

            try
            {
                var novoUsuario = await _userService.CadastrarUsuarioAsync(nome, email, senha);
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("email", ex.Message);
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            try
            {
                // Tenta autenticar o usuário
                var usuario = await _userService.AutenticarUsuarioAsync(email, senha);

                // Se o usuário for encontrado e a senha for correta, faz login e redireciona
                if (usuario != null)
                {
                    TempData["MensagemSucesso"] = "Login realizado com sucesso!";
                }
                else
                {
                    // Caso o login falhe, exibe uma mensagem de erro
                    TempData["MensagemErro"] = "E-mail ou senha inválidos!";
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro durante o processo de login
                TempData["MensagemErro"] = "Erro ao tentar realizar o login: " + ex.Message;
            }

            // Independentemente de o login ter sido bem-sucedido ou não, redireciona para a página de produtos
            return RedirectToAction("Produtos");
        }

        [HttpPost]
        public async Task<IActionResult> EnviarContato(Contact contato)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Salvando no banco de dados
                    _context.Contacts.Add(contato);
                    await _context.SaveChangesAsync();

                    // Mensagem de sucesso
                    TempData["MensagemSucesso"] = "Contato enviado com sucesso!";
                }
                catch (Exception ex)
                {
                    // Caso ocorra algum erro durante a operação no banco
                    TempData["MensagemErro"] = "Erro ao processar o contato: " + ex.Message;
                }

                // Redireciona de volta para a página de contato
                return RedirectToAction("Contact");
            }

            // Caso o modelo seja inválido
            TempData["MensagemErro"] = "Erro ao enviar o contato. Verifique os dados e tente novamente.";
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public IActionResult FinalizarCompra([FromForm] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                // Calcular o preço total com base na quantidade
                decimal precoUnitario = 0;
                switch (pedido.Produto)
                {
                    case "Alface Lisa":
                        precoUnitario = 2.5m;
                        break;
                    case "Alface Roxa":
                        precoUnitario = 3.0m;
                        break;
                    case "Alface Crespa":
                        precoUnitario = 2.8m;
                        break;
                    case "Alface Americana":
                        precoUnitario = 3.2m;
                        break;
                }

                // Preço total do pedido
                pedido.PrecoTotal = precoUnitario * pedido.Quantidade;

                // Definir a data do pedido
                pedido.DataPedido = DateTime.Now;

                // Salvar no banco de dados
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();

                //return Json(new { sucesso = true, mensagem = "Compra finalizada com sucesso!" });
                return RedirectToAction("Produtos");
            }

            // Caso o modelo esteja inválido
            //return Json(new { sucesso = false, mensagem = "Modelo de pedido inválido!", erros = ModelState.Values });
            TempData["MensagemErro"] = "Erro ao enviar o contato. Verifique os dados e tente novamente.";
            return RedirectToAction("Produtos");
        }

    }
}
