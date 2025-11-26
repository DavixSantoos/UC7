using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace apiAutenticacao.Services
{
    public class AuthServices
    {

        private readonly AppDbContext _context;

        public AuthServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<String> Login(LoginDTO dadosUsuarios)
        {



            Usuario? usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuarios.Email);

            if (usuarioEncontrado != null)
            {
                bool isValidPassword = Verify(dadosUsuarios.Senha, usuarioEncontrado.Senha);

                if (isValidPassword)
                {
                    return ("Login realizado com sucesso");

                }
                return ("Login não realizado. Email ou senha incorretos");
            }
            return ("Usuario não encontrado!");


        }

    }
}
