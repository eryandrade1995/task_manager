using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManager.API.DTOs.ViewModels
{
    public class TaskItemViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public string Status { get; set; }
        public string StatusText
        {
            get
            {
                return Status == "P" ? "Pendente" : "Concluída";
            }
        }

    }
}