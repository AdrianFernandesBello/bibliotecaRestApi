using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioBiblioteca.Infrastructure.Persistence
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {

        }

        //DB sets
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Emprestimo>(x =>
            {
                x.HasKey(e => e.Id);

                x.HasOne(x => x.Livro)
                .WithMany(e => e.Emprestimos)
                .HasForeignKey(fk => fk.IdLivro)
                .OnDelete(DeleteBehavior.Cascade);

                x.HasOne(x => x.Usuario)
                .WithMany(e => e.Emprestimos)
                .HasForeignKey(fk => fk.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Usuario>(x =>
            {
                x.HasKey(e => e.Id);                
            });



            builder.Entity<Livro>(x =>
            {
                x.HasKey(e => e.Id);
            });

            base.OnModelCreating(builder);
        }
    }

}

