using AgentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.DataService
{
    public class DepartmentData : IDepartment
    {
        private AgentContext _agentContext;
        public DepartmentData(AgentContext agentContext)
        {
            _agentContext = agentContext;
        }
        public Department AddDept(Department department)
        {
            _agentContext.Departments.Add(department);
            _agentContext.SaveChanges();
            return department;
        }

        public void DeleteDepartment(Department department)
        {
            _agentContext.Departments.Remove(department);
            _agentContext.SaveChanges();
        }

        public List<Department> Departments()
        {
            return _agentContext.Departments.ToList();
        }

        public Department GetDepartment(int deptId)
        {
            return _agentContext.Departments.Find(deptId);
        }

        public Department PutDepartment(Department department)
        {
            var existingDepartment = _agentContext.Departments.Find(department.DeptId);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                _agentContext.SaveChanges();
            }
            return department;
        }
    }
}
