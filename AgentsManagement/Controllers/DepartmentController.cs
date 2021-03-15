using AgentsManagement.DataService;
using AgentsManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.Controllers
{
   
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartment _department;
        public DepartmentController(IDepartment department)
        {
            _department = department;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public List<Department> Departments()
        {
            return _department.Departments();
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Addagent(Department department)
        {
            return Ok(_department.AddDept(department));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetDepartment(int id)
        {
            var existingDepartment = _department.GetDepartment(id);
            if (existingDepartment != null)
            {
                return Ok(existingDepartment);
            }
            else
            {
                return NotFound($"Department with id: {id} does not exist");
            }
        }
        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult PutDepartment(Department department)
        {
            var existingDepartment = _department.GetDepartment(department.DeptId);
            if (existingDepartment != null)
            {
                return Ok(_department.PutDepartment(department));
            }
            else
            {
                return NotFound("Department does not exist");
            }

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var existingDepartment = _department.GetDepartment(id);
            if (existingDepartment != null)
            {
                _department.DeleteDepartment(existingDepartment);
                return Ok("department deleted");

            }
            else
            {
                return NotFound("Department does not exist");
            }

        }
    }
}
