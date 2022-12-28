using AutoMapper;
using Pacagroup.Ecommerce.Aplicacion.DTO;
using Pacagroup.Ecommerce.Aplicacion.Interface;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Aplicacion.Main
{
    public class CustomersAplicacion : ICustomersAplicacion
    {
        private readonly ICustomersDomain _customersDomain;

        private readonly IMapper _mapper;

        private readonly IAppLogger<CustomersAplicacion> _logger;

        public CustomersAplicacion(ICustomersDomain customersDomain, IMapper mapper, IAppLogger<CustomersAplicacion> logger)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region  Metodos Sincronos
        public Response<bool> Insert(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Registro Exitoso";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Update(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Actualización Exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Eliminación Exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<CustomersDTO> Get(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Consulta Exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                }

                string message = "Consulta Exitosa";
                response.Message = message;
                _logger.LogInformation(message); //se va a grabar en la consola de ejecucion de vs -> (en "Salida" - Mostrar salida de "Debug") , el mensaje
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message); //se va a grabar en la consola de ejecucion de vs -> (en "Salida" - Mostrar salida de "Debug") , el mensaje
            }
            return response;
        }
        #endregion  Metodos Sincronos

        #region  Metodos Asincronos
        public async Task<Response<bool>> InsertAsync(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Registro Exitoso";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Actualización Exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Eliminación Exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Consulta Exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                }
                response.Message = "Consulta Exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion  Metodos Asincronos


    }
}
