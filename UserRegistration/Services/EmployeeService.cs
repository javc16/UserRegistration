using UserRegistration.Constants;
using UserRegistration.DBContext.Repository;
using UserRegistration.Domain;
using UserRegistration.Helpers;
using UserRegistration.Models;
using UserRegistration.Models.DTO;

namespace UserRegistration.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _context;
        private readonly EmployeeDomain _employeeDomain;

        public EmployeeService(IRepository<Employee> context, EmployeeDomain employeeDomain)
        {
            _context = context;
            _employeeDomain = employeeDomain;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _context.GetAll();
            var employeeDTOs = EmployeeDTO.FromModelToDTO(employees);
            return employeeDTOs;
        }

        public async Task<Response> GetById(int id)
        {
            var employee = await _context.GetById(id);
            if (employee == null)
            {
                return new Response
                {
                    Status = Constant.Failed,
                    Message = $"{Constant.This} {Constant.Employee} with id: {id} {Constant.DoesNotExist}"
                };
            }
            var employeeDTO = EmployeeDTO.FromModelToDTO(employee);
            return new Response
            {
                Status = Constant.Sucess,
                Message = "Retrieved Sucefully",
                Data = employeeDTO
            };
        }

        public Task<Response> SaveEmployee(EmployeeDTO employeeDTO)
        {
            var employees = _context.GetAll();
            var existingEmployee = employees.FirstOrDefault(x => x.EmployeeId.Equals(employeeDTO.EmployeeId));
            if (_employeeDomain.DuplicateEmployee(existingEmployee, employeeDTO))
            {
                return Task.FromResult(new Response
                {
                    Status = Constant.Failed,
                    Message = $"{Constant.This} {Constant.Employee} with id:{employeeDTO.EmployeeId} {Constant.Duplicated}"
                });
            }

            var employee = EmployeeDTO.FromDtoToModel(employeeDTO);
            _context.Add(employee);
            _context.SaveChanges();
            return Task.FromResult(new Response
            {
                Status = Constant.Sucess,
                Message = $"{Constant.This} {Constant.Employee} {Constant.SucefullyRegister}",
                Data = employeeDTO
            });
        }
    }
}
