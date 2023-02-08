using NewRampUpAssign2.Models;

namespace NewRampUpAssign2.Interface
{
    public interface IEmployee
    {
        public List<Employee> GetEmployeeDetails();
        public Employee GetEmployeeDetails(int id);
        public void AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int id);

    }
}
