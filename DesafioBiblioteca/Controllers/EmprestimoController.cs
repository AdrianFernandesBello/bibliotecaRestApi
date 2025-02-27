using DesafioBiblioteca.Application.Commands.DeleteEmprestimo;
using DesafioBiblioteca.Application.Commands.InsertEmprestimo;
using DesafioBiblioteca.Application.Commands.PostMarkEmprestimo;
using DesafioBiblioteca.Application.Commands.UpdateEmprestimo;
using DesafioBiblioteca.Application.Queries.GetAllEmprestimos;
using DesafioBiblioteca.Application.Queries.GetByIdEmprestimos;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBiblioteca.API.Controllers
{
    [Route("api/emprestimo")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly BibliotecaDbContext _context;

        public EmprestimoController(BibliotecaDbContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        //GET api/emprestimo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEmprestimoQuery();

            var result = _mediator.Send(query);

            return Ok(result);
        }

        // GET api/emprestimo/1
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdEmprestimosQuery(id);

            var emprestimoid = await _mediator.Send(query);

            if (emprestimoid == null)
            {
                return BadRequest( new {message = "Id nao existente"});
            }

            return Ok(emprestimoid);
        }

        //PUT api/emprestimo/1
        [HttpPut ("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmprestimoCommand command)
        {
            var empretimoid = _context.Emprestimo.SingleOrDefault(x => x.Id == id);
            if (empretimoid == null)
            {
                return BadRequest(new {message = "Id nao existe"});
            }

            _context.Emprestimo.Update(empretimoid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //POST api/emprestimo
        [HttpPost]
        public async Task<IActionResult> Post( InsertEmprestimoCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        //DELETE api/emprestimo/1
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmprestimoCommand(id));

            if (!result.IsSucess)
            {
               return BadRequest(result.Message);
            }

            return NoContent();
        }

        //POST api/emprestimo/1/MarkAtrasado
        [HttpPost ("{id}/MarkAtrasado")]
        public async Task<IActionResult> PostAtrasado(int id, CreateStatusInputCommand command)
        {
            var result = await _mediator.Send (command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Created();
        }

    }
}
