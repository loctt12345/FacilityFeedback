using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.TaskProcessPage
{
    public class DetailsModel : PageModel
    {
        private readonly ITaskProcessService _service;

        public DetailsModel(ITaskProcessService service)
        {
            _service = service;
        }

        public TaskProcess TaskProcess { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var taskProcess = await _service.GetById(id);
            if (taskProcess == null)
                return NotFound();
            TaskProcess = taskProcess;
            return Page();
        }
    }
}
