using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace FacilityFeedback.RazorPage.Pages.RoomPage
{
    public class CreateModel : PageModel
    {
        private readonly IFloorService _serviceFloor;
        private readonly IRoomTypeService _serviceRoomType;
        private readonly IRoomService _service;

        public CreateModel(IFloorService serviceFloor, IRoomTypeService serviceRoomType, IRoomService service)
        {
            _serviceFloor = serviceFloor;
            _serviceRoomType = serviceRoomType;
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {
            var floor = await _serviceFloor.GetAllNoPaging();
            ViewData["FloorId"] = new SelectList(await _serviceFloor.GetAllNoPaging(), "Id", "Code");
            ViewData["RoomTypeId"] = new SelectList(await _serviceRoomType.GetAllNoPaging(), "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Room == null)
            {
                return Page();
            }
            var isExistedRoomCode = (await _service.GetAllNoPaging()).Any(x=>x.RoomCode == Room.RoomCode);
            if (isExistedRoomCode)
            {
                ViewData["ErrorRoomCode"] = "Room Code Exsited";
                ViewData["FloorId"] = new SelectList(await _serviceFloor.GetAllNoPaging(), "Id", "Code");
                ViewData["RoomTypeId"] = new SelectList(await _serviceRoomType.GetAllNoPaging(), "Id", "Description");
                return Page();
            }
            var result = await _service.Create(Room);

            return RedirectToPage("./Index");
        }
    }
}
