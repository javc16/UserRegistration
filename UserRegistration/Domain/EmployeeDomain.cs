using UserRegistration.Models;
using UserRegistration.Models.DTO;

namespace UserRegistration.Domain
{
    public class EmployeeDomain
    {
        public bool DuplicateEmployee(Employee employee, EmployeeDTO employeeDTO)
        {
            if (employee != null && employee.EmployeeId.Equals(employeeDTO.EmployeeId))
            {
                return true;
            }
            return false;
        }
    }
}
