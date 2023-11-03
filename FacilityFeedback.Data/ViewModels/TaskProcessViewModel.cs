using FacilityFeedback.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Data.ViewModels
{
    public class TaskProcessViewModel
    {
        public List<TaskProcess> BaseTaskProcess { get; set; }
        public string State { get; set; }
    }
}
