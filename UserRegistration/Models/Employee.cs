namespace UserRegistration.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }


        public class Builder
        {
            private Employee _employee = new Employee();

            public Builder WithEmployeeId(string? employeeId)
            {
                _employee.EmployeeId = employeeId;
                return this;
            }

            public Builder WithFirstName(string? firstName)
            {
                _employee.FirstName = firstName;
                return this;
            }

            public Builder WithLastName(string? lastName)
            {
                _employee.LastName = lastName;
                return this;
            }

            public Builder WithDateOfBirth(DateTime dateOfBirth)
            {
                _employee.DateOfBirth = dateOfBirth;
                return this;
            }

            public Employee Build()
            {
                return _employee;
            }
        }
    }
}
