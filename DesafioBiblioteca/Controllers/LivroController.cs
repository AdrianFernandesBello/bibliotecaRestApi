using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBiblioteca.API.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly BibliotecaDbContext _context;

        public LivroController(BibliotecaDbContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        //GET api/livro
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok();
        }

        // GET api/livro/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        //PUT api/livro/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            return Ok();
        }

        //POST api/livro
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        //DELETE api/livro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
