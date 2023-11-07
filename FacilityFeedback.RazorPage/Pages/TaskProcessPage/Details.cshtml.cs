﻿using System;
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
        private readonly IProblemService _problemService;


        public DetailsModel(ITaskProcessService service, IProblemService problemService)
        {
            _service = service;
            _problemService = problemService;
        }

        public TaskProcess TaskProcess { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var problem = await _problemService.GetAllNoPaging();
            var taskProcess = await _service.GetById(id);
            if (taskProcess == null)
                return NotFound();
            taskProcess.Problem = problem.Where(p => p.Id == taskProcess.ProblemId).FirstOrDefault();

            TaskProcess = taskProcess;
            return Page();
        }
    }
}
