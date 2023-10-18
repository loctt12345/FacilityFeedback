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
            var floor = await _serviceFloor.GetAllNoPaging();
            ViewData["FloorId"] = new SelectList(await _serviceFloor.GetAllNoPaging(), "Id", "Code");
            ViewData["RoomTypeId"] = new SelectList(await _serviceRoomType.GetAllNoPaging(), "Id", "Description");
            var room = await _service.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                Room = room;
            }
            return Page();
        }


        
    }
}
