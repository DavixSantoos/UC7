using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using apiAutenticacao.Models.Repouse;
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

        public async Task<ResponseLogin> Login(LoginDTO dadosUsuarios)
        {



            Usuario? usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuarios.Email);

            if (usuarioEncontrado != null)
            {
                bool isValidPassword = Verify(dadosUsuarios.Senha, usuarioEncontrado.Senha);

                if (isValidPassword)
                {
                    return new ResponseLogin 
                    {
                        Erro = false,
                        Mensage = "Login realizado com sucesso",
                        Usuario = usuarioEncontrado
                    };

                }
                return new ResponseLogin 
                {
                    Erro = true,
                    Mensage = "Senha inválida",
                    Usuario = null
                };
            }
            return new ResponseLogin
            {
                Erro = true,
                Mensage = "Usuário não encontrado",
               
            };


        }

    }
}
