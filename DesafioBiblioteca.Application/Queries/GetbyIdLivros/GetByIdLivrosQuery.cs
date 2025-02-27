using DesafioBiblioteca.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Queries.GetbyIdLivros
{
    public class GetByIdLivrosQuery : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public GetByIdLivrosQuery(int id)
        {
            Id = id;
        }
    }
}
