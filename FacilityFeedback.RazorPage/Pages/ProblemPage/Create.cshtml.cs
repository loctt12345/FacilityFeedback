using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using NuGet.Protocol;

namespace FacilityFeedback.RazorPage.Pages.ProblemPage
{
    public class CreateModel : PageModel
    {
        private readonly IProblemService _service;
        private readonly IRoomService _roomService;
        private readonly IDeviceService _deviceService;
        
        public CreateModel(IProblemService service, IRoomService roomService, IDeviceService deviceService)
        {
            _service = service;
            _roomService = roomService;
            _deviceService = deviceService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["RoomId"] = new SelectList(await _roomService.GetAllNoPaging(), "Id", "RoomCode");
            return Page();
        }

        [BindProperty]
        public Problem Problem { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Problem.Device = null;
            if (!ModelState.IsValid || Problem == null)
            {
                ViewData["RoomId"] = new SelectList(await _roomService.GetAllNoPaging(), "Id", "RoomCode");
                return Page();
            }
            //Problem.DeviceId = 3;

            var result = await _service.Create(Problem);

            return RedirectToPage("./Index");
        }
        public async Task<JsonResult> OnGetDevice(int roomId)
        {
            var deviceList = await _deviceService.GetAllNoPaging();
            var deviceSelectList = new SelectList( deviceList.Where(d => d.RoomId == roomId), "Id", "Description");
            return new JsonResult(deviceSelectList);
        }
    }
}
