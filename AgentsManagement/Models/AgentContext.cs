using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.Models
{
    public class AgentContext: DbContext
    {
        public AgentContext(DbContextOptions<AgentContext> options) :base(options)
        {
                
        }

        public DbSet<Agent> Agents { get; set; }

       public DbSet<Department> Departments { get; set; }
    }
}
