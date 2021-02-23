using BL.Flows.Domain;

namespace BL.Flows.API.Dtos
{
    public class FlowUserManageDeptDtoPost : FlowUserManageDeptDtoBase
    {
        public FlowUserManageDept GetMapClass()
        {
            return new()
            {
                User = User,
                Departments = Departments
            };
        }
    }
}