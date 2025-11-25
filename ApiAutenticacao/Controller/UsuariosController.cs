using apiAutenticacao.Data;
using apiAutenticacao.Models;
using apiAutenticacao.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using static BCrypt.Net.BCrypt;

namespace apiAutenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context) { 
        
            _context = context;

        }

        [HttpPost("cadastrar")]
       public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CadastroUsuarioDTO dadosUsuario) {

            if (!ModelState.IsValid) { 

                return BadRequest(ModelState);
            }

            Usuario? usuarioExistente = await _context.Usuarios.
                FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuario.Email);

            if (usuarioExistente != null) {

                return BadRequest(new { erro = true, mensagem = "Este email já está cadastrado" });
            
            }

            Usuario usuario = new Usuario { 
            
                Nome = dadosUsuario.Nome,
                Email = dadosUsuario.Email,
                Senha = HashPassword(dadosUsuario.Senha),
                ConfirmarSenha = HashPassword(dadosUsuario.ConfirmarSenha)
                

            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { 

                erro = false,
                mensagem = "Usuário criado com sucesso",
                usuario = new {

                    id = usuario.Id,
                    nome = usuario.Nome,
                    email = usuario.Email

                }
               
            
            });

        
        
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dadosUsuarios)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }


        Usuario? usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == dadosUsuarios.Email);
       
        if (usuarioEncontrado != null) 
            {
                bool isValidPassword = Verify(dadosUsuarios.Senha, usuarioEncontrado.Senha);
           
               if (isValidPassword) 
                {
                    return Ok("Login realizado com sucesso");
               
                }
                return Unauthorized("Login não realizado. Email ou senha incorretos");
            }
            return NotFound("Usuario não encontrado!");
        
        
        }


    }
}
