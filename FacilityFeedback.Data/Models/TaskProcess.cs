using FacilityFeedback.Data.EnumModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Data.Models
{
    public class TaskProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset EndTime { get; set; }
        public string? Description { get; set; }
        public ProcessStatus Process { get; set; } = ProcessStatus.Waiting;
        public int ProblemId { get; set; }
        public string? StaffEmail {  get; set; }
        [ForeignKey("ProblemId")]
        public virtual Problem? Problem { get; set; }    
    }
}
