using DesafioBiblioteca.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Queries.GetbyIdUsuarios
{
    public class GetByIdUsuarioQuery : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public GetByIdUsuarioQuery(int id)
        {
            Id = id;
        }
    }
}
