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
        private readonly IProblemService _problemService;

        public DeleteModel(IDeviceService service, IDeviceTypeService deviceTypeService, IRoomService roomService,IProblemService problemService)
        {
            _service = service;
            _deviceTypeService = deviceTypeService;
            _roomService = roomService;
            _problemService = problemService;
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
            var problems = await _problemService.GetAllNoPaging();
            var isExsitedProblem = false;
            if(problems != null)
            {
                isExsitedProblem =  problems.Where(x=>x.DeviceId == id).Any();
            }
            if (!isExsitedProblem)
            {
                await _service.Delete(id);
            }
            else
            {
                var updateDevice = problems?.Where(x => x.DeviceId == id).Select(x => x.Device).FirstOrDefault();
                updateDevice.Status = false;
                await _service.Update(updateDevice);
            }

            return RedirectToPage("./Index");
        }
    }
}
