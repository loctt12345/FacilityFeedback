using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.ProblemPage
{
    public class DeleteModel : PageModel
    {
        private readonly IProblemService _service;
        private readonly ITaskProcessService _taskProcessService;


        public DeleteModel(IProblemService service, ITaskProcessService taskProcessService)
        {
            _service = service;
            _taskProcessService = taskProcessService;
        }

        [BindProperty]
        public Problem Problem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var problem = await _service.GetById(id);

            if (problem == null)
                return NotFound();

            Problem = problem;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.Delete(id);

            //Delete list Task
            var listTaskProcess = await _taskProcessService.GetAllNoPaging();
            var listTaskOfProblem = listTaskProcess.Where(tp => tp.Id == id).ToList();
            foreach (var item in listTaskOfProblem)
                await _taskProcessService.Delete(item.Id);

            return RedirectToPage("./Index");
        }
    }
}
