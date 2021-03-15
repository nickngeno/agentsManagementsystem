﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentsManagement.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
