using AgentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.DataService
{
   public interface IDepartment
    {
        public List<Department> Departments();

        Department AddDept(Department department);

        Department GetDepartment(int deptId);

        Department PutDepartment(Department department);

        void DeleteDepartment(Department department);
    }
}
