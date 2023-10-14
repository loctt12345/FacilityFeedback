using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Data.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public string RoomCode { get; set; }
        public string? Description { get; set; }
        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

    }
}
