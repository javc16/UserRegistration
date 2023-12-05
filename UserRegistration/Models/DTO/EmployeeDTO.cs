namespace UserRegistration.Models.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string? EmployeeId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public static EmployeeDTO FromModelToDTO(Employee employee)
        {

            var currentAge = DateTime.Today.Year - employee.DateOfBirth.Year;
            return employee != null ? new EmployeeDTO
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = DateTime.Today < employee.DateOfBirth.AddYears(currentAge) ? currentAge - 1 : currentAge,
                DateOfBirth = employee.DateOfBirth,
            } : new EmployeeDTO();
        }

        public static IEnumerable<EmployeeDTO> FromModelToDTO(IEnumerable<Employee> employees)
        {
            if (employees == null)
            {
                return new List<EmployeeDTO>();
            }
            List<EmployeeDTO> clienteData = new List<EmployeeDTO>();

            foreach (var item in employees)
            {
                clienteData.Add(FromModelToDTO(item));
            }

            return clienteData;
        }

        public static Employee FromDtoToModel(EmployeeDTO employeeDTO)
        {
            return employeeDTO != null ? new Employee.Builder().WithEmployeeId(employeeDTO.EmployeeId)
                .WithFirstName(employeeDTO.FirstName).WithLastName(employeeDTO.LastName).WithDateOfBirth(employeeDTO.DateOfBirth).Build() : new Employee();
        }
    }
}
