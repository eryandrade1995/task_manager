using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Core.Entities
{
    public class TaskItem
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string Code { get; set; }
        public string Description { get; set; }
        [StringLength(1)]
        public string Status { get; set; } = "P";
    }

}