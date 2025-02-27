using DesafioBiblioteca.Application.Commands.DeleteEmprestimo;
using DesafioBiblioteca.Application.Commands.DeleteLivro;
using DesafioBiblioteca.Application.Commands.InsertLivro;
using DesafioBiblioteca.Application.Commands.UpdateLivroCommand;
using DesafioBiblioteca.Application.Queries.GetAllLivros;
using DesafioBiblioteca.Application.Queries.GetByIdEmprestimos;
using DesafioBiblioteca.Application.Queries.GetbyIdLivros;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            var query = new GetAllLivrosQuery();

            var livros = await _mediator.Send(query);

            return Ok();
        }

        // GET api/livro/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdLivrosQuery(id);

            var livroid = await _mediator.Send(query);

            if (livroid == null)
            {
                return BadRequest(new { message = "Id nao existente" });
            }

            return Ok(livroid);

        }

        //PUT api/livro/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateLivroCommand command)
        {
            var livroid = _context.Livro.SingleOrDefault(x => x.Id == id);
            if (livroid == null)
            {
                return BadRequest(new { message = "Id nao existe" });
            }

            _context.Livro.Update(livroid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //POST api/livro
        [HttpPost]
        public async Task<IActionResult> Post(InsertLivroCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        //DELETE api/livro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLivroCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
