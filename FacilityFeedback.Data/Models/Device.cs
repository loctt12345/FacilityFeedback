using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Data.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTimeOffset ExpiredDay { get; set; }
        public string DeviceCode { get; set; }
        public string Manufacture { get; set; }
        public string? Description { get; set; }
        public int DeviceTypeId { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("DeviceTypeId")]
        public virtual DeviceType? DeviceType { get; set; }

        [ForeignKey("RoomId")]
        public Room? Room { get; set; }
    }
}
