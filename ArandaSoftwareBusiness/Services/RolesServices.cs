using ArandaSoftwareBusiness.Helper;
using ArandaSoftwareData.Helpers;
using ArandaSoftwareData.Model;
using ArandaSoftwareEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoftwareBusiness.Services
{
    public class RolesServices
    {
        //private RolesData RolesData;
        private readonly RepositoryBase<Roles, int> RolesData;
        public RolesServices(RepositoryBase<Roles, int> rolesData)
        {
            RolesData = rolesData;
        }
        public ResultData<List<RolesDTO>> List()
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
