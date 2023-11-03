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

namespace FacilityFeedback.RazorPage.Pages.ProblemPage
{
    public class EditModel : PageModel
    {
        private readonly IProblemService _service;
        private readonly IRoomService _roomService;
        private readonly IDeviceService _deviceService;
        public EditModel(IProblemService service, IRoomService roomService, IDeviceService deviceService)
        {
            _service = service;
            _roomService = roomService;
            _deviceService = deviceService;
        }

        [BindProperty]
        public Problem Problem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var problem = await _service.GetById(id);
            problem.Device = await _deviceService.GetById(problem.DeviceId);
            ViewData["RoomId"] = new SelectList(await _roomService.GetAllNoPaging(), "Id", "RoomCode", problem.Device.RoomId);

            if (problem == null)
            {
                return NotFound();
            }
            Problem = problem;
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
            var result = await _service.Update(Problem);
            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetDevice(int roomId)
        {
            var deviceList = await _deviceService.GetAllNoPaging();
            var deviceSelectList = new SelectList(deviceList.Where(d => d.RoomId == roomId), "Id", "Description");
            return new JsonResult(deviceSelectList);
        }
    }
}
