using DomainLayer.Models;
using DomainLayer.ModelsDto;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IRepository<RolUsuario> _repositoryRolUser;
        private readonly IConfiguracionGeneralService _configurationGeneralService;
        private readonly IEstadoService _estadoService;
        private readonly IRolService _rolService;
 

        public UsuarioService(
            IRepository<Usuario> repository,
            IRepository<RolUsuario> repositoryRolUser,
            IConfiguracionGeneralService configurationGeneralService,
            IEstadoService estadoService,
            IRolService rolService
         )
        {
            _repository = repository;
            _repositoryRolUser = repositoryRolUser;
            _configurationGeneralService = configurationGeneralService;
            _estadoService = estadoService;
            _rolService = rolService;
        }

        public ResponseDto GetByEmail(loginDto login)
        {
            //validar si el login.username es vacio
            if(login.Username == "" ||  login.Username == null)
            {
                ResponseDto response = new ResponseDto();
                response.Success = false;
                response.Message = "El email viene vacio desde azure";
                response.StatusCode = 401;
                response.Data = login;
                return response;
            }


            if (_repository.GetAllAsQueryable().FirstOrDefault(x => x.Email == login.Username) != null)
            {
                ResponseDto responseDto = new ResponseDto
                {
                    Success = true,
                    Message = "Usuario ya existe",
                    StatusCode = 200,
                    Data = _repository.GetAllAsQueryable().FirstOrDefault(x => x.Email == login.Username)
                };
                return responseDto;
            }
            else
            {

                Usuario usuario = new Usuario();
                usuario.Email = login.Username;
                usuario.Nombre = login.Name;
                usuario.isAdmin = login.isAdmin;
                usuario.EstadoId = 1;
                usuario.UserIdAzure = login.LocalAccountId;
                usuario.FechaCreacion = DateTime.Now;

                _repository.Insert(usuario);
                _repository.SaveChange();

                ResponseDto responseDto = new ResponseDto
                {
                    Success = false,
                    Message = "Proveedor no existe por lo que se procedio crear",
                    StatusCode = 200,
                    Data = _repository.GetAllAsQueryable().FirstOrDefault(x => x.Email == login.Username)
                };
                return responseDto;
            }
        }

    }
}
