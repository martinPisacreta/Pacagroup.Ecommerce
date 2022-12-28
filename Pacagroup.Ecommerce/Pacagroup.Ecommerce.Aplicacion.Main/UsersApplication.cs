using AutoMapper;
using Pacagroup.Ecommerce.Aplicacion.DTO;
using Pacagroup.Ecommerce.Aplicacion.Interface;
using Pacagroup.Ecommerce.Aplicacion.Validator;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;

namespace Pacagroup.Ecommerce.Aplicacion.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;

        private readonly IMapper _mapper;

        private readonly UsersDTOValidator _usersDTOValidator;


        public UsersApplication(IUsersDomain usersDomain, IMapper mapper,UsersDTOValidator usersDTOValidator)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _usersDTOValidator = usersDTOValidator;
        }

        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            var validation = _usersDTOValidator.Validate(new UsersDTO() { UserName = username, Password = password });

            if (validation.IsValid == false)
            {
                response.Message = "Errores de Validacion";
                response.Errors = validation.Errors; //aca estan todas las validaciones fallidas
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
