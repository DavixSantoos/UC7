using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiUsuarios.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {


        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World");
        }


        [HttpPost]
        public IActionResult HelloWorldPost([FromBody] String? login)
        {
            if (login == null)
            {
                return BadRequest("vocé não enviou os dados de login");
            }


           return Ok($"O Login enviado foi {login}");  
            //return Ok(
            //new {
            //nome = "David",
            //Sobrenome = "Carlos",
            //email = "Davidxsantos@outlook.com"
            //
            // });


        }
    }
}

