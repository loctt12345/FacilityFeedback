using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using FacilityFeedback.Service.Services;

namespace FacilityFeedback.RazorPage.Pages.RoomTypePage
{
    public class DeleteModel : PageModel
    {
        private readonly IRoomTypeService _service;
        private readonly IRoomService _roomService;

        public DeleteModel(IRoomTypeService service, IRoomService roomService)
        {
            _service = service;
            _roomService = roomService;
        }

        [BindProperty]
        public RoomType RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var roomType = await _service.GetById(id);

            if (roomType == null)
                return NotFound();

            RoomType = roomType;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var rooms = await _roomService.GetAllNoPaging();
            var isExsitedRoom = false;
            if (rooms != null)
            {
                isExsitedRoom = rooms.Where(x => x.RoomTypeId == id).Any();
            }
            if (!isExsitedRoom)
            {
                await _service.Delete(id);
            }
            else
            {
                var updateRoomTye = rooms?.Where(x => x.RoomTypeId == id).Select(x => x.RoomType).FirstOrDefault();
                updateRoomTye.Status = false;
                await _service.Update(updateRoomTye);
            }
            await _service.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
