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

       

        //public Usuario? ValidateUser(JwtClaimsDto claims)
        //{
        //    ConfiguracionGeneralDto general = _configurationGeneralService.GetByCode("JWT");
        //    if (general == null)
        //    {
        //        return null;
        //    }

        //    var appName = general.Valor1;
        //    var appId = general.Valor2;


        //    if (appName == null || appId == null)
        //    {
        //        return null;
        //    }

        //    if (appId != claims.AppId && appName != claims.AppDisplayName)
        //    {
        //        return null;
        //    }

        //    Usuario verifyUser = GetByEmail(claims.Email);
        //    Estado estado = _estadoService.GetEstadoById(3);
        //    Rol rol = _rolService.GetByCode("PRO");

        //    if (verifyUser == null)
        //    {
        //        // create new user
        //        verifyUser = new Usuario();
        //        verifyUser.Email = claims.Email;
        //        verifyUser.Nombre = claims.Name;
        //        verifyUser.EstadoId = estado.Id;
        //        verifyUser.UserIdAzure = appId;
        //        verifyUser.FechaCreacion = DateTime.Now;

        //        _repository.Insert(verifyUser);
        //        _repository.SaveChange();

        //        Usuario newUser = GetByEmail(claims.Email);

        //        RolUsuario rolUsuario = new RolUsuario();
        //        rolUsuario.UsuarioId = newUser.Id;
        //        rolUsuario.RolId = rol.Id;

        //        _repositoryRolUser.Insert(rolUsuario);
        //        _repositoryRolUser.SaveChange();
        //    }

        //    return verifyUser;
        //}

        //public Usuario getByIdUsuario(int id)
        //{
        //    return _repository.GetById(id);
        //}

        //public string? DecodeJwtTokenAzure(string token)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var jwtToken = tokenHandler.ReadJwtToken(token) as JwtSecurityToken;

        //        if (jwtToken != null)
        //        {
        //            // Verificar si Claims es nulo antes de intentar acceder a él
        //            if (jwtToken.Claims != null)
        //            {
        //                var emailClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "email");

        //                if (emailClaim != null)
        //                {
        //                    return emailClaim.Value;
        //                }
        //            }
        //        }
        //        // Si llegamos aquí, es porque no se encontró el reclamo "email" o había otros problemas con el token.
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al decodificar el token: " + ex.Message);
        //        return null;
        //    }
        //}

    }
}
