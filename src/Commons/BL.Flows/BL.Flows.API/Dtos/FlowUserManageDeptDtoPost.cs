using BL.Flows.API.Models;
using BL.Flows.Domain;

namespace BL.Flows.API.Dtos
{
    public class FlowUserManageDeptDtoPost : FlowUserManageDeptDtoBase
    {
        public FlowUserManageDept GetMapClass()
        {
            var obj = new FlowUserManageDept
            {
                User = User,
                Departments = Departments
            };
            return obj;
        }
    }
}