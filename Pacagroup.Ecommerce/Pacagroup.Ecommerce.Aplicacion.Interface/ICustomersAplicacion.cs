using Pacagroup.Ecommerce.Aplicacion.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Aplicacion.Interface
{
    public interface ICustomersAplicacion
    {
        #region  Metodos Sincronos
        Response<bool> Insert(CustomersDTO customersDTO);
        Response<bool> Update(CustomersDTO customersDTO);
        Response<bool> Delete(string customerId);
        Response<CustomersDTO> Get(string customerId);
        Response<IEnumerable<CustomersDTO>> GetAll();
        #endregion  Metodos Sincronos

        #region  Metodos Asincronos
        Task<Response<bool>> InsertAsync(CustomersDTO customersDTO);
        Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        #endregion  Metodos Asincronos
    }
}
