using NewRampUpAssign2.Models;

namespace NewRampUpAssign2.Interface
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployeeDetails();
        Task<Employee> GetEmployeeDetails(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task <Employee>UpdateEmployee(Employee employee);
        Task <Employee>DeleteEmployee(int id);
       
    }
}
