using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArandaSoftwareBusiness.Helper;
using ArandaSoftwareData.Helpers;
using ArandaSoftwareData.Model;
using ArandaSoftwareEntities.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArandaSoftwareTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
       

        private readonly ILogger<RolesController> _logger;
        //private readonly RolesServices _rolesService;

        private readonly IRepositoryBase<Roles, int> RolesData;
        public RolesController(ILogger<RolesController> logger, IRepositoryBase<Roles, int> rolesData)
        {
            _logger = logger;
           // _rolesService = rolesServices;
            RolesData = rolesData;
        }

        [HttpGet]
        public ResultData<List<RolesDTO>> Get()
        {
            try
            {
                var result = RolesData.GetAll();
                var ListRta = AutoMapp<Roles, RolesDTO>.ConvertList(result);
                return ResultData<List<RolesDTO>>.Sucess(ListRta, "Consulta exitosa");
            }
            catch (Exception ex)
            {

                return ResultData<List<RolesDTO>>.Issue(null, "Opps ha ocurrido un error", ex);
            }
            
        }
    }
}
