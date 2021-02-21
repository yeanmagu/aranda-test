using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArandaSoftwareBusiness.Helper;
using ArandaSoftwareData.Helpers;
using ArandaSoftwareData.Model;
using ArandaSoftwareEntities.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ArandaSoftwareTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {


        private readonly ILogger<UsersController> _logger;
        private readonly ArandaModel _ctx;

        private readonly IRepositoryBase<Users, int> UsersData;
        public UsersController(ILogger<UsersController> logger, IRepositoryBase<Users, int> UsersData, ArandaModel ctx)
        {
            _logger = logger;
            _ctx = ctx;
            this.UsersData = UsersData;
        }

        [HttpGet]
        public ResultData<List<UsersDTO>> Get()
        {
            try
            {
                var result = this.UsersData.GetAll();
                var ListRta = AutoMapp<Users, UsersDTO>.ConvertList(result);
                return ResultData<List<UsersDTO>>.Sucess(ListRta, "Consulta exitosa");
            }
            catch (Exception ex)
            {

                return ResultData<List<UsersDTO>>.Issue(null, "Opps ha ocurrido un error", ex);
            }

        }
       
        [HttpPost]
        public ActionResult Post([FromBody] UsersDTO obj)
        {
            try
            {

                var mapp = AutoMapp<UsersDTO, Users>.Convert(obj);
                if (obj.Id > 0)
                {
                    if (!string.IsNullOrEmpty(obj.Password))
                    {
                        mapp.Password = Encrypt.GenSHA256(obj.Password);
                    }
                    else
                        mapp.Password = UsersData.GetById(obj.Id).Password;

                    var ListRta = this.UsersData.Update(mapp, obj.Id);
                }
                else
                {
                    mapp.Password = Encrypt.GenSHA256(obj.Password);
                    var ListRta = this.UsersData.Add(mapp);
                }

                obj.Id = mapp.Id;
                return Ok(ResultData<UsersDTO>.Sucess(obj, "Usuario Guardado de manera exitosa"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResultData<UsersDTO>.Issue(null, "Opps ha ocurrido un error", ex));
            }

        }
        [HttpPut]
        public ActionResult Edit([FromBody] UsersDTO obj)
        {
            try
            {

               
                 var mapp = AutoMapp<UsersDTO, Users>.Convert(obj);
                if (mapp.Id > 0)
                {
                    if (!string.IsNullOrEmpty(obj.Password))
                    {
                        mapp.Password = Encrypt.GenSHA256(obj.Password);
                    }
                    else
                    {
                        mapp.Password = this._ctx.Users.AsNoTracking().Where(c=> c.Id==obj.Id).FirstOrDefault().Password;
                    }
                    var ListRta = this.UsersData.Update(mapp, obj.Id);
                    return Ok(ResultData<UsersDTO>.Sucess(obj, "Usuario Guardado de manera exitosa"));
                }
                return NotFound("No se encontraron datos con la información enviada");
            }
            catch (Exception ex)
            {
                return BadRequest(ResultData<UsersDTO>.Issue(null, "Opps ha ocurrido un error", ex));
            }

        }
        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] LoginDto obj)
        {
            try
            {
                    Users User = _ctx.Users
                    .Where(x => x.Username == obj.Username).FirstOrDefault(); ;

                if (User == null)
                {
                    return NotFound($"usuario no existe");
                }
                var userPass = Encrypt.GenSHA256(obj.Password);
                var x = _ctx.Entry(User);
                if (User.Password != userPass)
                {                   
                    return BadRequest("Contraseña errada, por favor intentelo de nuevo");
                }
                var ListRta = AutoMapp<Users, LoginResult>.Convert(User);
                var rol = _ctx.Roles.Find(User.RolesId);
                var permisos = _ctx.Permisos.Where(c=> c.RolId == User.RolesId).FirstOrDefault();
                ListRta.Permisos = AutoMapp<Permisos, PermisosDTO>.Convert(permisos);
                ListRta.Rol = AutoMapp<Roles, RolesDTO>.Convert(rol);
                return Ok(ResultData<LoginResult>.Sucess(ListRta, "Usuario Guardado de manera exitosa"));
            }
            catch (Exception ex)
            {
                return BadRequest( ResultData<UsersDTO>.Issue(null, "Opps ha ocurrido un error", ex));
            }

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public ResultData<bool> Delete(int id)
        {
            try
            {
                var Rta = this.UsersData.Delete(id);
                if (Rta)
                {
                    return ResultData<bool>.Sucess(Rta, "Usuario Eliminado de manera exitosa");
                }
                else
                {
                    return ResultData<bool>.Sucess(Rta, "Usuario No se ha podido eliminar");
                }
                
            }
            catch (Exception ex)
            {
                return ResultData<bool>.Issue(false, "Opps ha ocurrido un error", ex);
            }

        }     
    }
}
