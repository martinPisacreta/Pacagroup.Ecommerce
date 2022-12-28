using FluentValidation.Results;
using System.Collections.Generic;

namespace Pacagroup.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; } //va a tener la respuesta de la capa Dominio
        public bool IsSuccess { get; set; } //informacion del estado de la ejecucion
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; } //devuelve la lista de validaciones fallidas usando la libreria FluentValidation

    }
}
