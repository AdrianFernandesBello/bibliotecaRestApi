using DesafioBiblioteca.Application.Commands.UpdateEmprestimo;
using DesafioBiblioteca.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services

                .AddHandlers();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<UpdateEmprestimoCommand>());

            return services;
        }
    }
}
