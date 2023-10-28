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
    public class DetailsModel : PageModel
    {
        private readonly IDeviceService _service;
        private readonly IDeviceTypeService _deviceTypeService;
        private readonly IRoomService _roomService;

        public DetailsModel(IDeviceService service, IDeviceTypeService deviceTypeService, IRoomService roomService)
        {
            _service = service;
            _deviceTypeService = deviceTypeService;
            _roomService = roomService;
        }

        public Device Device { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
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
    }
}
