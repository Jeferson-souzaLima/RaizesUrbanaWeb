using RaizesUrbanaWeb.Models;
using Microsoft.EntityFrameworkCore;
using RaizesUrbanaWeb.Data;

namespace RaizesUrbanaWeb.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CadastrarUsuarioAsync(string nome, string email, string senha)
        {
            // Verificar se o e-mail já está registrado
            var userExistente = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (userExistente != null)
            {
                throw new InvalidOperationException("Este e-mail já está registrado.");
            }

            // Criar o novo usuário
            var novoUsuario = new User
            {
                Name = nome,
                Email = email,
                Password = senha,  // Salvando a senha diretamente (sem criptografia)
                Type = UserType.Regular, // Definindo como "Regular" por padrão
            };

            // Salvar no banco de dados
            _context.Users.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return novoUsuario;  // Retorna o usuário criado
        }

        public async Task<User> AutenticarUsuarioAsync(string email, string senha)
        {
            // Procura o usuário no banco de dados pelo e-mail
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            // Verifica se o usuário foi encontrado
            if (usuario == null)
            {
                return null;  // E-mail não encontrado
            }

            // Verifica se a senha fornecida é a mesma do banco de dados
            if (usuario.Password != senha)
            {
                return null;  // Senha incorreta
            }

            return usuario;  // Login bem-sucedido
        }

    }
}
