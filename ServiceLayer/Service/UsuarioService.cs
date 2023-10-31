using DomainLayer.Models;
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
        private IRepository<Usuario> _repository;
        private readonly IConfiguracionGeneralService _configurationGeneralService;
        private readonly IEstadoService _estadoService;
        private readonly IRolService _rolService;

        public UsuarioService(
            IRepository<Usuario> repository
         )
        {
            _repository = repository;
        }

        public Usuario GetByEmail(string email)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Email == email) ?? null;
        }

        public Usuario? ValidateUser(JwtClaims claims)
        {
            ConfiguracionGeneral general = _configurationGeneralService.GetByCode("JWT");
            if (general == null)
            {
                return null;
            }

            var appName = general.Valor1;
            var appId = general.Valor2;
            

            if (appName == null || appId == null)
            {
                return null;
            }

            if ( appId != claims.AppId && appName != claims.AppDisplayName )
            {
                return null;
            }

            Usuario verifyUser = GetByEmail(claims.Email);
            Estado estado = _estadoService.GetEstadoById(3);
            Rol rol = _rolService.GetByCode("PRO");

            if (verifyUser == null)
            {
                // create new user
                verifyUser = new Usuario();
                verifyUser.Email = claims.Email;
                verifyUser.Nombre = claims.Name;
                verifyUser.EstadoId = estado.Id;
                verifyUser.UserIdAzure = appId;
                verifyUser.FechaCreacion = DateTime.Now;

                _repository.Insert(verifyUser); 

                Usuario newUser = GetByEmail(claims.Email);

                RolUsuario rolUsuario = new RolUsuario();
                rolUsuario.UsuarioId = newUser.Id;
                rolUsuario.RolId = rol.Id;
                rolUsuario.CreadoPor = newUser.Id;
                rolUsuario.FechaCreacion = DateTime.Now;
            }

            return verifyUser;
        }

    }
}
