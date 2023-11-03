using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.DevicePage
{
    public class DeleteModel : PageModel
    {
        private readonly IDeviceService _service;
        private readonly IDeviceTypeService _deviceTypeService;
        private readonly IRoomService _roomService;

        public DeleteModel(IDeviceService service, IDeviceTypeService deviceTypeService, IRoomService roomService)
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
                device.DeviceType = await _deviceTypeService.GetById(device.DeviceTypeId);
                device.Room = await _roomService.GetById(device.RoomId);
                Device = device;
            }
            return Page();
        }

        [BindProperty]
        public Device Device { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
