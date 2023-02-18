using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewRampUpAssign2.Interface;
using NewRampUpAssign2.Models;


namespace NewRampUpAssign2.Repository
{
    public class EmployeeRepository : IEmployee
    {
        readonly DataContext _dbContext = new();
       

        public EmployeeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
         
        }

        public Task<List<Employee>>GetEmployeeDetails()
        {
            try
            {
                return Task.FromResult(_dbContext.Employees.ToList());
            }
            catch
            {
                throw;
            }
        }

        public Task<Employee> GetEmployeeDetails(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    return Task.FromResult(employee);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return Task.FromResult(employee);
            }
            catch
            {
                throw ;
            }
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return Task.FromResult(employee);


            }
            catch
            {
                throw;
            }
        }

        public Task<Employee> DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);

                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    return Task.FromResult(employee);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

      
    }
}
