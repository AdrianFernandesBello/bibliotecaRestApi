using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBiblioteca.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //GET api/usuario
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        // GET api/usuario/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        //PUT api/usuario/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            return Ok();
        }

        //POST api/usuario
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        //DELETE api/usuario/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
