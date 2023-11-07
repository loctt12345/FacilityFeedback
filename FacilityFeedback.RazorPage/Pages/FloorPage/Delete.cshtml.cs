using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.FloorPage
{
    public class DeleteModel : PageModel
    {
        private readonly IFloorService _service;
        private readonly IRoomService _roomService;

        public DeleteModel(IFloorService service, IRoomService roomService)
        {
            _service = service;
            _roomService = roomService;
        }

        [BindProperty]
        public Floor Floor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var floor = await _service.GetById(id);

            if (floor == null)
                return NotFound();

            Floor = floor;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var rooms = await _roomService.GetAllNoPaging();
            var isExsitedRoom = false;
            if (rooms != null)
            {
                isExsitedRoom = rooms.Where(x => x.FloorId == id).Any();
            }
            if (!isExsitedRoom)
            {
                await _service.Delete(id);
            }
            else
            {
                var updateFloor = rooms?.Where(x => x.FloorId == id).Select(x => x.Floor).FirstOrDefault();
                updateFloor.Status = false;
                await _service.Update(updateFloor);
            }
            return RedirectToPage("./Index");
        }
    }
}
