using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacilityFeedback.RazorPage.Pages.RoomPage
{
    public class DetailsModel : PageModel
    {
        private readonly IFloorService _serviceFloor;
        private readonly IRoomTypeService _serviceRoomType;
        private readonly IRoomService _service;

        public DetailsModel(IFloorService serviceFloor, IRoomTypeService serviceRoomType, IRoomService service)
        {
            _serviceFloor = serviceFloor;
            _serviceRoomType = serviceRoomType;
            _service = service;
        }
        public Room Room { get; set; } = default!;

        public async Task<IActionResult> OnGet(int id)
        {
            var room = await _service.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                room.Floor = await _serviceFloor.GetById(room.FloorId);
                room.RoomType = await _serviceRoomType.GetById(room.RoomTypeId);
                Room = room;
                
            }
            return Page();
        }


        
    }
}
