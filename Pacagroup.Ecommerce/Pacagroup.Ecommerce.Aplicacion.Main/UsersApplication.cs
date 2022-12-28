using AutoMapper;
using Pacagroup.Ecommerce.Aplicacion.DTO;
using Pacagroup.Ecommerce.Aplicacion.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;

namespace Pacagroup.Ecommerce.Aplicacion.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;

        private readonly IMapper _mapper;


        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }

        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parametros no puede ser vacios";
                return response;
            }

            try
            {
                var users = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDTO>(users);
                response.IsSuccess = true;
                response.Message = "Autenticacion Exitosa!!!";

            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
    }
}
