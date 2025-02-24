using DesafioBiblioteca.Application.Commands.DeleteEmprestimo;
using DesafioBiblioteca.Core.Entities;
using DesafioBiblioteca.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Application.Models
{
    public class EmprestimoItemViewModel
    {
        public EmprestimoItemViewModel(int idUsuario, int idLivro, DateTime dataEmprestimo,EmprestimoEnum status)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmprestimo = dataEmprestimo;
            Status = status;
        }

        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public EmprestimoEnum Status { get; set; }


        public static EmprestimoItemViewModel FromEntity(Emprestimo emprestimo)
        => new(emprestimo.IdUsuario, emprestimo.IdLivro, emprestimo.DataEmprestimo,
           emprestimo.Status);
    }
}
