using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.RoomPage
{
    public class EditModel : PageModel
    {
        private readonly IFloorService _serviceFloor;
        private readonly IRoomTypeService _serviceRoomType;
        private readonly IRoomService _service;

        public EditModel(IFloorService serviceFloor, IRoomTypeService serviceRoomType, IRoomService service)
        {
            _serviceFloor = serviceFloor;
            _serviceRoomType = serviceRoomType;
            _service = service;
        }

        [BindProperty]
        public Room Room { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {


            var room = await _service.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            Room = room;
            ViewData["FloorId"] = new SelectList(await _serviceFloor.GetAllNoPaging(), "Id", "Code");
            ViewData["RoomTypeId"] = new SelectList(await _serviceRoomType.GetAllNoPaging(), "Id", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _service.Update(Room);
            

            return RedirectToPage("./Index");
        }

        
    }
}
