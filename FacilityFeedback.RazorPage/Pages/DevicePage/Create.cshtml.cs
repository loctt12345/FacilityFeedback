using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.DevicePage
{
    public class CreateModel : PageModel
    {
        private readonly IDeviceService _service;
        private readonly IDeviceTypeService _deviceTypeService;
        private readonly IRoomService _roomService;

        public CreateModel(IDeviceService service, IDeviceTypeService deviceTypeService, IRoomService roomService)
        {
            _service = service;
            _deviceTypeService = deviceTypeService;
            _roomService = roomService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["DeviceTypeId"] = new SelectList(await _deviceTypeService.GetAllNoPaging(), "Id", "Name");
            ViewData["RoomId"] = new SelectList(await _roomService.GetAllNoPaging(), "Id", "RoomCode");
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
            var result = await _service.Create(Device);

            return RedirectToPage("./Index");
        }
    }
}
