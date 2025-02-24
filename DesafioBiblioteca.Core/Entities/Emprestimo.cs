using DesafioBiblioteca.Core.Enums;

namespace DesafioBiblioteca.Core.Entities
{
    public  class Emprestimo : BaseEntity
    {
        public Emprestimo(int idUsuario, int idLivro,decimal valor)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            Valor = valor;

            Status = EmprestimoEnum.Criado;
        }

        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolução { get; set; }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public decimal Valor { get; set; }
        public EmprestimoEnum Status { get; set; }
        public DateTime PagoEm { get; set; }

        public void Update(decimal valor)
        {
            Valor = valor;
        }

        public void EmprestimoCriado()
        {
            if (Status == EmprestimoEnum.Criado)
            {
                Status = EmprestimoEnum.EmAndamento;
                DataEmprestimo = DateTime.Now;
                DataDevolução = DataEmprestimo.AddDays(30);
            }
        }

        public void EmprestimoConcluido()
        {
            if (Status == EmprestimoEnum.EmAndamento || Status == EmprestimoEnum.PagamentoPendente)
            {
                Status = EmprestimoEnum.Concluido;
                PagoEm = DateTime.Now;
            }
        }

        public void EmprestimoAtrasado()
        {
            if (Status == EmprestimoEnum.PagamentoPendente )
            {
                Status = EmprestimoEnum.Atrasado;
            }
        }

        public void EmpretimoPagamentoPendente()
        {
            if(Status == EmprestimoEnum.EmAndamento)
            {
                Status = EmprestimoEnum.PagamentoPendente;
            }

        }

    }
}
