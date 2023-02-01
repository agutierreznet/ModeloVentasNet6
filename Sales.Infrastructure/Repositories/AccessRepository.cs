using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Entities;
using Sales.ApplicationCore.Interfaces;
using Sales.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class AccessRepository : IAccessRepository
    {
        private readonly SalesContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AccessRepository(SalesContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public List<UsuarioDto> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UsuarioDto GetUser(string nombre, string contrasenia)
        {
            if(_context.Usuarios.Count()==0)
            {
                AddUsersDefault();
            }

            Usuario existe = _context.Usuarios.
                Where(x => x.NombreUsuario == nombre && x.Contrasenia == contrasenia).FirstOrDefault();

            if (existe != null)
            {
                UsuarioDto obj = _mapper.Map<UsuarioDto>(existe);
                obj.token = GetToken(obj.IdUsuario);
                return obj;
            }
            else
            {
                return null;
            }
        }


        private string GetToken(int IdUsuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, IdUsuario.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private void AddUsersDefault()
        {
            _context.Add(new Usuario { IdUsuario = 1, NombreUsuario = "admin", Contrasenia = "123" });
            _context.Add(new Usuario { IdUsuario = 2, NombreUsuario = "user", Contrasenia = "123" });
            _context.SaveChanges();
        }

    }
}
