using ASP_JWT.Interfaces;
using ASP_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_JWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var returnValue = (List<Employee>) await _employeeRepository.GetAll();
            return Ok(returnValue);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> Post(Employee employee)
        {
            bool isSave = _employeeRepository.Add(employee);
            if (isSave)
            {
                var returnValue = (List<Employee>)await _employeeRepository.GetAll();
                return Ok(returnValue);
            }
            return BadRequest("Cannot Save new data");
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Edit(int id, Employee employee)
        {
            Employee returnValue = await _employeeRepository.GetById(id);
            if (returnValue == null)
            {
                return BadRequest("Cannot find data with this id " + id);
            }

            returnValue.NationalIDNumber = employee.NationalIDNumber;
            returnValue.EmployeeName = employee.EmployeeName;
            returnValue.LoginID = employee.LoginID;
            returnValue.JobTitle = employee.JobTitle;
            returnValue.BirthDate = employee.BirthDate;
            returnValue.MaritalStatus = employee.MaritalStatus;
            returnValue.Gender = employee.Gender;
            returnValue.HireDate = employee.HireDate;
            returnValue.VacationHours = employee.VacationHours;
            returnValue.SickLeaveHours = employee.SickLeaveHours;
            returnValue.RowGuid = employee.RowGuid;
            returnValue.ModifiedDate = employee.ModifiedDate;


            bool isSave = _employeeRepository.Update(returnValue);
            if (isSave)
            {
                return Ok(returnValue);
            }
            return BadRequest("Cannot save data with this id " + id);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            Employee returnValue = await _employeeRepository.GetById(id);
            if (returnValue == null)
            {
                return BadRequest("Cannot find data with this id " + id);
            }

            bool isSave = _employeeRepository.Delete(returnValue);
            if (isSave)
            {
                return Ok(await _employeeRepository.GetAll());
            }
            return BadRequest("Cannot delete data with this id " + id);
        }
    }
}
