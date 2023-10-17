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

        public CreateModel(ITaskProcessService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskProcess TaskProcess { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || TaskProcess == null)
            {
                return Page();
            }
            var result = await _service.Create(TaskProcess);

            return RedirectToPage("./Index");
        }
    }
}
