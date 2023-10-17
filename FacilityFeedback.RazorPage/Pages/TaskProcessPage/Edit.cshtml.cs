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

namespace FacilityFeedback.RazorPage.Pages.TaskProcessPage
{
    public class EditModel : PageModel
    {
        private readonly ITaskProcessService _service;

        public EditModel(ITaskProcessService service)
        {
            _service = service;
        }

        [BindProperty]
        public TaskProcess TaskProcess { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var taskProcess = await _service.GetById(id);
            if (taskProcess == null)
            {
                return NotFound();
            }
            TaskProcess = taskProcess;
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
            var result = await _service.Update(TaskProcess);
            return RedirectToPage("./Index");
        }
    }
}
