using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.TaskProcessPage
{
    public class CreateModel : PageModel
    {
        private readonly ITaskProcessService _service;
        private readonly IProblemService _problemService;


        public CreateModel(ITaskProcessService service, IProblemService problemService)
        {
            _service = service;
            _problemService = problemService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["ProblemId"] = new SelectList(await _problemService.GetAllNoPaging(), "Id", "Description");
            return Page();
        }

        [BindProperty]
        public TaskProcess TaskProcess { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (TaskProcess.EndTime < TaskProcess.StartTime)
                ModelState.AddModelError("TaskProcess.StartTime",
                                 "End Time must be after Start Time.");

            if (!ModelState.IsValid || TaskProcess == null)
            {
                ViewData["ProblemId"] = new SelectList(await _problemService.GetAllNoPaging(), "Id", "Description");
                return Page();
            }
            var result = await _service.Create(TaskProcess);

            return RedirectToPage("./Index");
        }
    }
}
