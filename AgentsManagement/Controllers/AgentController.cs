using AgentsManagement.DataService;
using AgentsManagement.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.Controllers
{
    [ApiController]
    public class AgentController : ControllerBase
    {
        private IAgent _agentdata;
        private IWebHostEnvironment _env;
        public AgentController(IAgent agentdata, IWebHostEnvironment env)
        {
            _agentdata = agentdata;
            _env = env;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public List<Agent> Agents()
        {
            return _agentdata.Agents();
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Addagent(Agent agent)
        {
            return Ok(_agentdata.AddAgent(agent));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Getagent(int id)
        {
            var existingAgent = _agentdata.GetAgent(id);
            if(existingAgent != null)
            {
                return Ok(existingAgent);
            }
            else
            {
               return NotFound($"Agent with id: {id} does not exist");
            }
        }
        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Editagent(Agent agent)
        {
            var existingAgent = _agentdata.GetAgent(agent.AgentId);
            if (existingAgent != null)
            {
                return Ok(_agentdata.EditAgent(agent));
            }
            else
            {
                return NotFound("Agent does not exist");
            }
            
        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Deleteagent(int id)
        {
            var existingAgent = _agentdata.GetAgent(id);
            if (existingAgent != null)
            {
                _agentdata.DeleteAgent(existingAgent);
                return Ok("deleted");
            }
            else
            {
                return NotFound($"Agent with id: {id} does not exist");
            }
            
        }
        [HttpPost]
        [Route("api/[controller]/saveprofile")]
        public IActionResult Savefile()
        {
            try
            {
                var httprequest = Request.Form;
                var requestfile = httprequest.Files[0];
                var filename = requestfile.FileName;
                var physicalpath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalpath, FileMode.Create))
                {
                    requestfile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch(Exception)
            {
                return NotFound("anonymous.png");
            }
        }
      
    }
}
