using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Aplicacion.Validator;

namespace Pacagroup.Ecommerce.Servicio.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            //AddTransient -> se crea una nueva instancia de la clase UsersDTOValidator por cada peticion
            services.AddTransient<UsersDTOValidator>();
            return services;
        }
    }
}
