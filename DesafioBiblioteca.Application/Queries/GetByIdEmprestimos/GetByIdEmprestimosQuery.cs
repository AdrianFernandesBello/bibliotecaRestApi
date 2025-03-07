﻿using DesafioBiblioteca.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Queries.GetByIdEmprestimos
{
    public class GetByIdEmprestimosQuery : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public GetByIdEmprestimosQuery(int id)
        {
            Id = id;
        }
    }
}
