using AgentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.DataService
{
    public class AgentData : IAgent
    {
        private AgentContext _agentContext;
        public AgentData(AgentContext agentContext)
        {
            _agentContext = agentContext;
        }
        public Agent AddAgent(Agent agent)
        {
            _agentContext.Agents.Add(agent);
            _agentContext.SaveChanges();
            return agent;
        }

        public List<Agent> Agents()
        {
            return _agentContext.Agents.ToList();
        }

        public void DeleteAgent(Agent agent)
        {
            _agentContext.Agents.Remove(agent);
            _agentContext.SaveChanges();
        }

        public Agent EditAgent(Agent agent)
        {
            var existingAgent = _agentContext.Agents.Find(agent.AgentId);
            if(existingAgent != null)
            {
                existingAgent.AgentId = agent.AgentId;
                existingAgent.FirstName = agent.FirstName;
                existingAgent.LastName = agent.LastName;
                existingAgent.Department = agent.Department;
                existingAgent.DateofJoining = agent.DateofJoining;
                existingAgent.Picture = agent.Picture;
                _agentContext.Agents.Update(existingAgent);
                _agentContext.SaveChanges();
            }
            return agent;

        }

        public Agent GetAgent(int id)
        {
            return _agentContext.Agents.Find(id);
        }
    }
}
