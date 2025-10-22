using ClienteApi.Data;
using ClienteApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClienteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context) {
            _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes() {
            List<Cliente> listaClientes = await _context.Clientes.ToListAsync();
            return Ok(listaClientes);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente) {
            
            _context.Clientes.Add(cliente);
            int result = await _context.SaveChangesAsync();

            if (result == 1) 
            {
                return Ok("Cliente criado com sucesso");
            }
            return Ok("Usuário não cadastrado");
        }       
    } 
}
