
namespace Pacagroup.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; } //va a tener la respuesta de la capa Dominio
        public bool IsSuccess { get; set; } //informacion del estado de la ejecucion
        public string Message { get; set; }

    }
}
