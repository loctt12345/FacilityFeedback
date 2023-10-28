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

namespace FacilityFeedback.RazorPage.Pages.DevicePage
{
    public class EditModel : PageModel
    {
        private readonly IDeviceService _service;
        private readonly IDeviceTypeService _deviceTypeService;
        private readonly IRoomService _roomService;

        public EditModel(IDeviceService service, IDeviceTypeService deviceTypeService, IRoomService roomService)
        {
            _service = service;
            _deviceTypeService = deviceTypeService;
            _roomService = roomService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var device = await _service.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["DeviceTypeId"] = new SelectList(await _deviceTypeService.GetAllNoPaging(), "Id", "Name");
                ViewData["RoomId"] = new SelectList(await _roomService.GetAllNoPaging(), "Id", "RoomCode");
                Device = device;
            }
            return Page();
        }

        [BindProperty]
        public Device Device { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Device == null)
            {
                return Page();
            }
            var result = await _service.Update(Device);

            return RedirectToPage("./Index");
        }
    }
}
