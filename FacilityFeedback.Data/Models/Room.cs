using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Data.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoomCode { get; set; }
        public bool Status { get; set; }
        public int FloorId { get; set; }
        public int RoomTypeId { get; set; }

        [ForeignKey("FloorId")]
        public virtual Floor? Floor { get; set; }
        [ForeignKey("RoomTypeId")]
        public RoomType? RoomType { get; set; }
    }
}
