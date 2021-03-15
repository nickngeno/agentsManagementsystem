using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }

        [MaxLength(50)]
        [Required]
        public string AgentName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Department { get; set; }

        public string DateofJoining { get; set; }

        public string Picture { get; set; }
    }
}
