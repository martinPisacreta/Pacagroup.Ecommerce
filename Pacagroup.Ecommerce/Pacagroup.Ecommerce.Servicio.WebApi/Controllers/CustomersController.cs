using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Aplicacion.DTO;
using Pacagroup.Ecommerce.Aplicacion.Interface;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Servicio.WebApi.Controllers
{
    [Authorize] //todas las operaciones del controlador requieren autorizacion
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersAplicacion _customersAplicacion;
        public CustomersController(ICustomersAplicacion customersAplicacion)
        {
            _customersAplicacion = customersAplicacion;
        }

        #region  Metodos Sincronos

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = _customersAplicacion.Insert(customersDTO);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = _customersAplicacion.Update(customersDTO);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = _customersAplicacion.Delete(customerId);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = _customersAplicacion.Get(customerId);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var response = _customersAplicacion.GetAll();
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        #endregion  Metodos Sincronos

        #region  Metodos Asincronos
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = await _customersAplicacion.InsertAsync(customersDTO);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = await _customersAplicacion.UpdateAsync(customersDTO);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = await _customersAplicacion.DeleteAsync(customerId);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest(); //PARAMETRO INVALIDO
            }

            var response = await _customersAplicacion.GetAsync(customerId);
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {

            var response = await _customersAplicacion.GetAllAsync();
            if (response.IsSuccess == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        #endregion  Metodos Asincronos

    }
}
