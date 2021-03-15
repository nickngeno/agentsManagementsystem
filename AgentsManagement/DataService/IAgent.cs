using AgentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.DataService
{
    public interface IAgent
    {
        public List<Agent> Agents();

        Agent AddAgent(Agent agent);

        Agent GetAgent(int id);

        Agent EditAgent(Agent agent);

        void DeleteAgent(Agent agent);
    }
}
