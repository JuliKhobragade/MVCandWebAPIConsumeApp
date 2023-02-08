using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewRampUpAssign2.Interface;
using NewRampUpAssign2.Models;

namespace NewRampUpAssign2.Controllers
{
    
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmployee;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployee IEmployee,IMapper mapper)
        {
            _IEmployee = IEmployee;
            _mapper = mapper;
        }

        // GET: api/employee>
        [Authorize]
        [HttpGet]
        public ActionResult<List<EmpData>> GetEmployeeDetails()
        {
/*             var employee= await Task.FromResult(_IEmployee.GetEmployeeDetails());
*/
            var employees =  _IEmployee.GetEmployeeDetails();
            var records = _mapper.Map<List<EmpData>>(employees);
            return Ok(records);


        }

        // GET api/employee/
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpData>> GetEmployeeDetails(int id)
        {
            var employees = await Task.FromResult(_IEmployee.GetEmployeeDetails(id));
            if (employees == null)
            {
                 return NotFound();
                //throw new Exception("This EmpId is not valid.");
            }
            var employee = _mapper.Map<EmpData>(employees);
            return Ok(employee);
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(EmpData empData)
        {
            var employee = _mapper.Map<Employee>(empData);
            _IEmployee.AddEmployee(employee);
            return await Task.FromResult(employee);
        }

        // PUT api/employee/
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmpData empData)
        {
            int empId = empData.EmployeeID;

            var records = await Task.FromResult(_IEmployee.GetEmployeeDetails(empId));

            if (records == null)
            {
                throw new Exception($"empId not found.");
            }

            _mapper.Map(empData, records);

            try
            {
                await _IEmployee.UpdateEmployee(records);
            }
            catch (Exception)
            {
                throw new Exception("Error occured while updating empId");
            }

            return Ok("Employee Details Updated");
        }

        // DELETE api/employee/
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = _IEmployee.DeleteEmployee(id);
            return Ok("Employee Data Deleted");
        }

      /*  private bool EmployeeExists(int id)
        {
            return _IEmployee.CheckEmployee(id);
        }*/
    }
}