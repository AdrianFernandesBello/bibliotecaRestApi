using DesafioBiblioteca.Application.Commands.DeleteEmprestimo;
using DesafioBiblioteca.Application.Commands.DeleteUsuario;
using DesafioBiblioteca.Application.Commands.InsertUsuario;
using DesafioBiblioteca.Application.Commands.UpdateUsuario;
using DesafioBiblioteca.Application.Queries.GetAllEmprestimos;
using DesafioBiblioteca.Application.Queries.GetAllUSuario;
using DesafioBiblioteca.Application.Queries.GetByIdEmprestimos;
using DesafioBiblioteca.Application.Queries.GetbyIdUsuarios;
using DesafioBiblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DesafioBiblioteca.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly BibliotecaDbContext _context;

        public UsuarioController(BibliotecaDbContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        //GET api/usuario
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUSuarioQuery();

            var result = _mediator.Send(query);

            return Ok(result);

        }

        // GET api/usuario/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUsuarioQuery(id);

            var usuarioid = await _mediator.Send(query);

            if (usuarioid == null)
            {
                return BadRequest(new { message = "Id nao existente" });
            }

            return Ok(usuarioid);
        }

        //PUT api/usuario/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUsuarioCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //POST api/usuario
        [HttpPost]
        public async Task<IActionResult> Post(InsertUsuarioCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        //DELETE api/usuario/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUsuarioCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
