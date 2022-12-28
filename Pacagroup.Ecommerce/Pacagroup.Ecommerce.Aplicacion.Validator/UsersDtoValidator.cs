using System;
using FluentValidation;
using Pacagroup.Ecommerce.Aplicacion.DTO;

namespace Pacagroup.Ecommerce.Aplicacion.Validator
{
    public class UsersDTOValidator : AbstractValidator<UsersDTO>
    {
        public UsersDTOValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty(); //la propiedad UserName no sea nula y tampoco vacia
            RuleFor(u => u.Password).NotNull().NotEmpty(); //la propiedad Password no sea nula y tampoco vacia
        }
    }
}
